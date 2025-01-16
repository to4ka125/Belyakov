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
using Belyakov.Forms;
namespace Belyakov
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tx1.Text == "user")
            {
                if (pw1.Password=="user")
                {
                    MainForm mn = new MainForm();
                    this.Visibility = Visibility.Hidden;
                    mn.ShowDialog();
                    this.Visibility = Visibility.Visible;
                }
                else
                {
                    Cap cap = new Cap();
                    this.Visibility = Visibility.Hidden;
                    cap.ShowDialog();
                    this.Visibility = Visibility.Visible;

                    MessageBox.Show("Пароль введен не верно");
                }
            }
            else
            {
                MessageBox.Show("Данного пользователя не существует");
            }
        }

        private void pw1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = (TextBlock)pw1.Template.FindName("textBlock", pw1);
            if (pw1.Password.Length > 0)
            {
                textBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                textBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
