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

namespace PetShop.Desktop.LoginWindow
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string MyProperty = "9564df11-f4a6-4347-8507-1dde4586ee5f";
            string MyProperty1 = "$2a$11$j8DkyaFlPw8Wjt5ZDPlAge1QlQfxs1bLUWA0KlROsxeieAREjsdSq";
            string s = txtPwd.Password.ToString();

            string User = txtUser.Text;

            var a = Verify(s, MyProperty1, MyProperty);

            if (a && User.Equals("Admin"))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Username yoki Password xato kiritilgan!");
            }
        }

        private bool Verify(string s, string myProperty1, string myProperty)
        {
            throw new NotImplementedException();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
