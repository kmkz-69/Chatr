using Chatr.ViewModel;
using Chatr.Views;
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

namespace Chatr
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

      

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            var signup = new SignUp();
            signup.Show();
            this.Close();
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Tab)
            {
                if (Password.Password == "")
                {
                    Password.Password = "Password";
                    Password.Foreground = new SolidColorBrush();
                }
            }

        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;
            if(e.Key == Key.Enter)
            {
                if(Username.Text == "")
                {
                    Username.Text = "Username / Email";
                    Username.Foreground = new SolidColorBrush();
                }
                e.Handled = true;
                uie.MoveFocus(
                    new TraversalRequest(FocusNavigationDirection.Previous));
            }
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            if(Password.Password == "Password")
            {
                Password.Password = "";
                Password.Foreground = new SolidColorBrush();
            }
        }

        private void FortgotPassword_Click(object sender, RoutedEventArgs e)
        {
            var resetPassword = new ResetPassword();
            resetPassword.Show();
            this.Close();   
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
           var contentMain = new ContentMain();
           contentMain.Show();
           this.Close();
        }
    }
}
