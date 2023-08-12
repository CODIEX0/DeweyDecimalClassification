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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DeweyDecimalClassification.Windows;

namespace DeweyDecimalClassification
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReplaceBooks_Click(object sender, RoutedEventArgs e)
        {
            ReplaceBooks replaceBooks = new ReplaceBooks();

            List<string> callNumbers = GenerateRandomCallNumbers();
            List<int> index = GenerateRandomIndex();
            List<TextBlock> textBlocks = new List<TextBlock>() { replaceBooks.txtcn1, replaceBooks.txtcn2, replaceBooks.txtcn3, replaceBooks.txtcn4, replaceBooks.txtcn5, replaceBooks.txtcn6, replaceBooks.txtcn7, replaceBooks.txtcn8, replaceBooks.txtcn9, replaceBooks.txtcn10 };

            Console.WriteLine("Assigned values:");
            for(int i = 0; i < callNumbers.Count; i++)
            {
                textBlocks[i].Text = callNumbers[i];
            }

            Visibility = Visibility.Hidden;

            replaceBooks.Show();
        }

        private void btnIdentifyingAreas_Click(object sender, RoutedEventArgs e)
        {

            //alert the user that they signed in successfully
            MessageBox.Show("The Identifying Areas task is not implemented yet. ", "Feature not implemented!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnFindingCallNumbers_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Finding Call Numbers task is not implemented yet.", "Feature not implemented!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        static List<string> GenerateRandomCallNumbers()
        {
            List<string> callNumbers = new List<string>();

            List<int> numbers = new List<int> { 600, 200, 800, 000, 700, 400, 900, 100, 300, 500 };

            // Pre-defined list of Dewey Decimal System call numbers
            List<string> orderedCallNumbers = new List<string> { "000", "100", "200", "300", "400", "500", "600", "700", "800", "900" };

            // Create a new instance of the Random class
            Random random = new Random();
            HashSet<int> usedIndices = new HashSet<int>();

            while (callNumbers.Count < 10)
            {
                int index;
                do
                {
                    index = random.Next(numbers.Count);
                } while (usedIndices.Contains(index));

                usedIndices.Add(index);
                callNumbers.Add(numbers[index].ToString("D3"));
            }

            return callNumbers;
        }

        static List<int> GenerateRandomIndex()
        {
            List<int> numbers = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int newNumber;
                do
                {
                    newNumber = rand.Next(0, 10);
                } while (numbers.Contains(newNumber));

                numbers.Add(newNumber);
            }

            return numbers;
        }
    }
}
