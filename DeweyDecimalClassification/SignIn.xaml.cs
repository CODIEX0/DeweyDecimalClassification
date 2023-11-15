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
        public string student_number, name;

        public SignIn()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            //creating a main window object
            MainWindow mainWindow = new MainWindow();

            //assign values from the sign in window to the 2 labels
            student_number = txtStudentNumber.Text;
            name = txtNames.Text;

            mainWindow.txtName.Content = name.ToUpper();
            mainWindow.txtStudentNumber.Content = student_number.ToUpper();

            if(name.Length > 0 )
            {
                //alert the user that they signed in successfully
                MessageBox.Show($"Signed In As {name}", "Signed In", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //alert the user that they signed in successfully
                MessageBox.Show("Successfully Signed In!", "Signed In", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            

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
