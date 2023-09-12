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
using System.Windows.Shapes;

namespace DeweyDecimalClassification
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void txtStudentNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNames_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            //hide the current window
            Visibility = Visibility.Hidden;
            //open the main window
            mainWindow.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //shutdown the application
            Application.Current.Shutdown();
        }
    }
}
