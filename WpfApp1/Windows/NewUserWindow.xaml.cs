using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        public NewUserWindow(List<string> cb_data)
        {
            
            InitializeComponent();
            CBRole.ItemsSource = cb_data;
            CBRole.SelectedItem = "Клиент";
        }

        private void TB_Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]) && !(Authorization.validchars().Contains(e.Text[0]));
        }

        private void TB_FIO_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text[0].ToString(), "[^a-zA-Zа-яА-Я-]");
        }

        private void TB_Password_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text[0].ToString(), "[^a-zA-Z0-9]");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Authorization.CreateUser(TB_Phone.Text, TB_FIO.Text, TB_Password.Text, CBRole.SelectedIndex))
            {
                GetWindow(this).Close();
            }
        }
    }
}
