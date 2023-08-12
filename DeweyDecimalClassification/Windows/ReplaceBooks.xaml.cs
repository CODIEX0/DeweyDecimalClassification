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

namespace DeweyDecimalClassification.Windows
{
    /// <summary>
    /// Interaction logic for ReplaceBooks.xaml
    /// </summary>
    public partial class ReplaceBooks : Window
    {
        // Pre-defined list of Dewey Decimal System call numbers
        private static List<string> orderedCallNumbers = new List<string> { "000", "100", "200", "300", "400", "500", "600", "700", "800", "900" };
        private static int percentage;
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
            if(!string.IsNullOrEmpty(this.tbxcn1.Text) && !string.IsNullOrEmpty(this.tbxcn2.Text) && !string.IsNullOrEmpty(this.tbxcn3.Text) && !string.IsNullOrEmpty(this.tbxcn4.Text) && !string.IsNullOrEmpty(this.tbxcn5.Text) &&
                !string.IsNullOrEmpty(this.tbxcn6.Text) && !string.IsNullOrEmpty(this.tbxcn7.Text) && !string.IsNullOrEmpty(this.tbxcn8.Text) && !string.IsNullOrEmpty(this.tbxcn9.Text) && !string.IsNullOrEmpty(this.tbxcn10.Text))
            {
                List<TextBox> userOrder = new List<TextBox>() { this.tbxcn1, this.tbxcn2, this.tbxcn3, this.tbxcn4, this.tbxcn5, this.tbxcn6, this.tbxcn7, this.tbxcn8, this.tbxcn9, this.tbxcn10 };
                // Pre-defined list of Dewey Decimal System call numbers
                List<string> callNumbers = new List<string> { "000", "100", "200", "300", "400", "500", "600", "700", "800", "900" };

                bool correctOrder = true;
                for (int i = 0; i < userOrder.Count; i++)
                {
                    if (userOrder[i].Text != callNumbers[i])
                    {
                        correctOrder = false;
                        break;
                    }
                }

                if (correctOrder)
                {
                    //alert the user that they ordered the numbers correctly
                    MessageBox.Show("Congratulations! Your ordering is perfect. ;-)", "Books Replaced", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Oops! Your ordering is incorrect. Here's the correct order", "Order Incorrect", MessageBoxButton.OK, MessageBoxImage.Error);
                    for (int i = 0; i < callNumbers.Count; i++)
                    {
                        userOrder[i].Text = callNumbers[i];
                    }
                }
            }
            else
            {
                //alert the user that they ordered the numbers correctly
                MessageBox.Show("Please fill in all the text box's.", "Task Incomplete", MessageBoxButton.OK, MessageBoxImage.Warning);
            }            
        }

        private void tbxcn1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (tbxcn1.Text.Equals(orderedCallNumbers[0]))
            {
                percentage += 10;
                DoubleAnimation da = new DoubleAnimation(0, percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
            else
            {
                DoubleAnimation da = new DoubleAnimation(percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }            
        }

        private void tbxcn2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (tbxcn2.Text.Equals(orderedCallNumbers[1]))
            {
                percentage += 10;
                DoubleAnimation da = new DoubleAnimation(percentage - 10, percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
            else
            {
                DoubleAnimation da = new DoubleAnimation(percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
        }

        private void tbxcn3_TextChanged(object sender, TextChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (tbxcn3.Text.Equals(orderedCallNumbers[2]))
            {
                percentage += 10;
                DoubleAnimation da = new DoubleAnimation(percentage - 10, percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
            else
            {
                DoubleAnimation da = new DoubleAnimation(percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
        }

        private void tbxcn4_TextChanged(object sender, TextChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (tbxcn4.Text.Equals(orderedCallNumbers[3]))
            {
                percentage += 10;
                DoubleAnimation da = new DoubleAnimation(percentage - 10, percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
            else
            {
                DoubleAnimation da = new DoubleAnimation(percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
        }

        private void tbxcn5_TextChanged(object sender, TextChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (tbxcn5.Text.Equals(orderedCallNumbers[4]))
            {
                percentage += 10;
                DoubleAnimation da = new DoubleAnimation(percentage - 10, percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
            else
            {
                DoubleAnimation da = new DoubleAnimation(percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
        }

        private void tbxcn6_TextChanged(object sender, TextChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (tbxcn6.Text.Equals(orderedCallNumbers[5]))
            {
                percentage += 10;
                DoubleAnimation da = new DoubleAnimation(percentage - 10, percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
            else
            {
                DoubleAnimation da = new DoubleAnimation(percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
        }

        private void tbxcn7_TextChanged(object sender, TextChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (tbxcn7.Text.Equals(orderedCallNumbers[6]))
            {
                percentage += 10;
                DoubleAnimation da = new DoubleAnimation(percentage - 10, percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
            else
            {
                DoubleAnimation da = new DoubleAnimation(percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
        }

        private void tbxcn8_TextChanged(object sender, TextChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (tbxcn8.Text.Equals(orderedCallNumbers[7]))
            {
                percentage += 10;
                DoubleAnimation da = new DoubleAnimation(percentage - 10, percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
            else
            {
                DoubleAnimation da = new DoubleAnimation(percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
        }

        private void tbxcn9_TextChanged(object sender, TextChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (tbxcn9.Text.Equals(orderedCallNumbers[8]))
            {
                percentage += 10;
                DoubleAnimation da = new DoubleAnimation(percentage - 10, percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
            else
            {
                DoubleAnimation da = new DoubleAnimation(percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
        }

        private void tbxcn10_TextChanged(object sender, TextChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (tbxcn10.Text.Equals(orderedCallNumbers[9]))
            {
                percentage += 10;
                DoubleAnimation da = new DoubleAnimation(percentage - 10, percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
            else
            {
                DoubleAnimation da = new DoubleAnimation(percentage, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, da);
            }
        }
    }
}
