using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

/*
* CODE ATTRIBUTION - PROGRESS BAR / ANIMATION
* https://wpf-tutorial.com/misc-controls/the-progressbar-control/
*/

/*
* CODE ATTRIBUTION - DURATION METHOD
* https://learn.microsoft.com/en-us/dotnet/api/system.timespan.duration?view=net-7.0
*/

/*
* CODE ATTRIBUTION - DURATION METHOD
* https://learn.microsoft.com/en-us/dotnet/api/system.timespan.duration?view=net-7.0
*/

namespace DeweyDecimalClassification.Windows
{
    /// <summary>
    /// Interaction logic for ReplaceBooks.xaml
    /// </summary>
    public partial class ReplaceBooks : Window
    {
        // Pre-defined list of Dewey Decimal System call numbers
        private static List<string> orderedCallNumbers = new List<string> { "000", "100", "200", "300", "400", "500", "600", "700", "800", "900" };
        private static double percentage;
        Duration duration = new Duration(TimeSpan.FromSeconds(1));
        public ReplaceBooks()
        {
            percentage = 0;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Visibility = Visibility.Collapsed;
            main.Show();
        }

        private void btnReplaceBooks_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbxcn1.Text) && !string.IsNullOrEmpty(this.tbxcn2.Text) && !string.IsNullOrEmpty(this.tbxcn3.Text) && !string.IsNullOrEmpty(this.tbxcn4.Text) && !string.IsNullOrEmpty(this.tbxcn5.Text) &&
                !string.IsNullOrEmpty(this.tbxcn6.Text) && !string.IsNullOrEmpty(this.tbxcn7.Text) && !string.IsNullOrEmpty(this.tbxcn8.Text) && !string.IsNullOrEmpty(this.tbxcn9.Text) && !string.IsNullOrEmpty(this.tbxcn10.Text))
            {
                List<TextBlock> textBlocks = new List<TextBlock>() { txtcn1, txtcn2, txtcn3, txtcn4, txtcn5, txtcn6, txtcn7, txtcn8, txtcn9, txtcn10 };
                List<TextBox> userOrder = new List<TextBox>() { this.tbxcn1, this.tbxcn2, this.tbxcn3, this.tbxcn4, this.tbxcn5, this.tbxcn6, this.tbxcn7, this.tbxcn8, this.tbxcn9, this.tbxcn10 };
               
                // Pre-defined list of Dewey Decimal System call numbers
                List<int> callNumbers = new List<int> { 600, 200, 800, 000, 700, 400, 900, 100, 300, 500 };
                List<string> callNumbersString = new List<string> { "000", "100", "200", "300", "400", "500", "600", "700", "800", "900" };

                QuickSort(callNumbers, 0, callNumbers.Count - 1);
                
                bool correctOrder = true;

                for (int i = 0; i < userOrder.Count; i++)
                {

                    if (userOrder[i].Text != callNumbersString[i])
                    {
                        correctOrder = false;
                        break;
                    }
                }

                if (correctOrder)
                {
                    ImgFire.Visibility = Visibility.Visible;
                    txtComment.Text = "Your ordering is perfect. ;-)";
                    //alert the user that they ordered the numbers correctly
                    MessageBox.Show("Congratulations! Your ordering is perfect. ;-)", "Books Replaced", MessageBoxButton.OK, MessageBoxImage.Information);                    
                }
                else
                {
                    progressBar.Foreground = Brushes.Red; // change the foreground color 
                    percentage = 0;  // set the percentage of the progress bar to 0

                    //alert the user that they're ordering is incorrect.
                    MessageBox.Show("Oops! Your ordering is incorrect. Here's the correct order", "Order Incorrect", MessageBoxButton.OK, MessageBoxImage.Error);

                    txtOrderNumbers.Text = "Here Are The Call Numbers In Ascending Order";
                    txtComment.Text = "Nice Try, Feel Free To Try Again."; // motivate the user with a nice comment


                    // Animation to update the progress bar with the new percentage
                    DoubleAnimation da = new DoubleAnimation(percentage, duration);
                    progressBar.BeginAnimation(ProgressBar.ValueProperty, da);

                    for (int i = 0; i < textBlocks.Count; i++)
                    {
                        if (i == 0)
                        {
                            textBlocks[i].Text = callNumbers[i].ToString() + "00";
                            userOrder[i].Text = null;
                        }
                        else
                        {
                            textBlocks[i].Text = callNumbers[i].ToString();
                            userOrder[i].Text = null;
                        }
                    }
                }
            }
            else
            {
                //alert the user that they ordered the numbers correctly
                MessageBox.Show("Please fill in all the text box's.", "Task Incomplete", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /*
         * CODE ATTRIBUTION - QUICK SORT ALGORITHM
         * https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-9.php
         */

        //quick sort algorithm to sort the call number entered by the user

        static void QuickSort(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(list, low, high);
                QuickSort(list, low, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, high);
            }
        }

        static int Partition(List<int> list, int low, int high)
        {
            int pivotValue = list[high];
            int smallerIndex = low - 1;

            for (int i = low; i < high; i++)
            {
                if (list[i] <= pivotValue)
                {
                    smallerIndex++;
                    Swap(list, smallerIndex, i);
                }
            }
            Swap(list, smallerIndex + 1, high);
            return smallerIndex + 1;
        }

        static void Swap(List<int> list, int index1, int index2)
        {
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        private void UpdatePercentage(object sender)
        {
            TextBox textBox = (TextBox)sender;

            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[0]);
            double perc = percentage;

            if (enteredCorrectValue)
            {
                percentage += 10; // Increase percentage by 10
            }
            else
            {
                percentage -= 10; // Deduct 10 from percentage
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }

        private void tbxcn1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; // Get the sender TextBox
            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[0]);
            // Check if the user entered the correct call number
            if (enteredCorrectValue)
            {
                progressBar.Foreground = Brushes.Red; // change the foreground color 
                percentage += 10; // Increase percentage by 10
                txtComment.Text = "Nice Start"; // motivate the user with a nice comment
                // If the user entered the correct call number, disable the text box and
                textBox.IsEnabled = false;                
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }

        private void tbxcn2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; // Get the sender TextBox
            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[1]);
            // Check if the user entered the correct call number
            if (enteredCorrectValue)
            {
                progressBar.Foreground = Brushes.IndianRed; // change the foreground color 
                percentage += 10; // Increase percentage by 10
                txtComment.Text = "Keep Going"; // motivate the user with a nice comment
                // If the user entered the correct call number, disable the text box and
                textBox.IsEnabled = false;
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }

        private void tbxcn3_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; // Get the sender TextBox
            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[2]);
            // Check if the user entered the correct call number
            if (enteredCorrectValue)
            {

                progressBar.Foreground = Brushes.LightCoral; // change the foreground color 
                percentage += 10; // Increase percentage by 10
                txtComment.Text = "You're On fire"; // motivate the user with a nice comment
                // If the user entered the correct call number, disable the text box and
                textBox.IsEnabled = false;
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }

        private void tbxcn4_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; // Get the sender TextBox
            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[3]);
            // Check if the user entered the correct call number
            if (enteredCorrectValue)
            {
                progressBar.Foreground = Brushes.Coral; // change the foreground color 
                percentage += 10; // Increase percentage by 10
                txtComment.Text = "Great Job"; // motivate the user with a nice comment
                // If the user entered the correct call number, disable the text box and
                textBox.IsEnabled = false;
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }

        private void tbxcn5_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; // Get the sender TextBox
            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[4]);
            // Check if the user entered the correct call number
            if (enteredCorrectValue)
            {
                progressBar.Foreground = Brushes.DarkOrange; // change the foreground color 
                percentage += 10; // Increase percentage by 10
                txtComment.Text = "Awesome Work"; // motivate the user with a nice comment
                // If the user entered the correct call number, disable the text box and
                textBox.IsEnabled = false;
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }

        private void tbxcn6_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; // Get the sender TextBox
            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[5]);
            // Check if the user entered the correct call number
            if (enteredCorrectValue)
            {
                progressBar.Foreground = Brushes.Gold; // change the foreground color 
                percentage += 10; // Increase percentage by 10
                txtComment.Text = "Impressive Streak"; // motivate the user with a nice comment
                // If the user entered the correct call number, disable the text box and
                textBox.IsEnabled = false;
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }

        private void tbxcn7_TextChanged(object sender, TextChangedEventArgs e)
        {
            progressBar.Foreground = Brushes.Khaki; // change the foreground color 
            TextBox textBox = (TextBox)sender; // Get the sender TextBox
            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[6]);
            // Check if the user entered the correct call number
            if (enteredCorrectValue)
            {
                percentage += 10; // Increase percentage by 10
                txtComment.Text = "Fantastic Progress"; // motivate the user with a nice comment
                // If the user entered the correct call number, disable the text box and
                textBox.IsEnabled = false;
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }

        private void tbxcn8_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; // Get the sender TextBox
            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[7]);
            // Check if the user entered the correct call number
            if (enteredCorrectValue)
            {
                progressBar.Foreground = Brushes.LightGreen; // change the foreground color 
                percentage += 10; // Increase percentage by 10
                txtComment.Text = "Incredible Accuracy"; // motivate the user with a nice comment
                // If the user entered the correct call number, disable the text box and
                textBox.IsEnabled = false;
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }

        private void tbxcn9_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; // Get the sender TextBox
            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[8]);
            // Check if the user entered the correct call number
            if (enteredCorrectValue)
            {
                progressBar.Foreground = Brushes.MediumSeaGreen; // change the foreground color 
                percentage += 10; // Increase percentage by 10
                txtComment.Text = "Unstoppable Force"; // motivate the user with a nice comment
                // If the user entered the correct call number, disable the text box and
                textBox.IsEnabled = false;
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }

        private void tbxcn10_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; // Get the sender TextBox
            bool enteredCorrectValue = textBox.Text.Equals(orderedCallNumbers[9]);
            // Check if the user entered the correct call number
            if (enteredCorrectValue)
            {
                progressBar.Foreground = Brushes.Green; // change the foreground color 
                percentage += 10; // Increase percentage by 10
                txtComment.Text = "Triumphant Mastery"; // motivate the user with a nice comment
                // If the user entered the correct call number, disable the text box and
                textBox.IsEnabled = false;
            }

            // Animation to update the progress bar with the new percentage
            DoubleAnimation da = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
        }
    }
}

