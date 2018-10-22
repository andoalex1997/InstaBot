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
using InstaBot.Core;
using InstaBot.Core.PageModels;

namespace InstaBot.DesktopApp
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {

        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameTb.Text) || string.IsNullOrEmpty(PasswordTb.Password))
            {
                MessageBox.Show("Username or password id empty");
                return;
            }

            var logPage = new LogInPage(UsernameTb.Text, PasswordTb.Password);
            logPage.LogIn();
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
            
        }
    }
}
