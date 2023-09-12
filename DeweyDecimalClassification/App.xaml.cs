using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DeweyDecimalClassification
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Appication_Startup(object sender, StartupEventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
        }
    }
}
