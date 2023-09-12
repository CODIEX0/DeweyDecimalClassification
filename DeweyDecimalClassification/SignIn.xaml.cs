using System;
using System.Collections.Generic;
using System.Globalization;
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
            //creating a main window object
            MainWindow mainWindow = new MainWindow();

            //assign values from the sign in window to the 3 labels
            mainWindow.txtName.Content = txtNames.Text.ToUpper();
            mainWindow.txtStudentNumber.Content = txtStudentNumber.Text.ToUpper();

            //alert the user that they signed in successfully
            MessageBox.Show("Successfully Signed In!", "Signed In", MessageBoxButton.OK, MessageBoxImage.Information);

            //hide the current window
            Visibility = Visibility.Hidden;
            //open the main window
            mainWindow.Show();
           
            if (string.IsNullOrEmpty(txtStudentNumber.Text))
            {
                mainWindow.lblStudentNumber.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrEmpty(txtNames.Text))
            {
                mainWindow.lblName.Visibility = Visibility.Hidden;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //shutdown the application
            Application.Current.Shutdown();
        }
    }
}
