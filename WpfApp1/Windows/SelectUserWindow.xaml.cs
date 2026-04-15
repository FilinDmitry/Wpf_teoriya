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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ServiceNew.xaml
    /// </summary>
    public partial class ServiceNew : Window
    {
        ServiceDisplayModel displayModel;
        List<User> users;
        public User selected_user;
        public ServiceNew()
        {
            InitializeComponent();
            users = Core.Context.User.Where(i => i.Role.Name == "Мастер").ToList();
            ListBox.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selected_user = ListBox.SelectedItem as User;
            if (selected_user != null)
            {
                GetWindow(this).Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBox.ItemsSource = users.Where(i => i.FIO.ToLower().Contains(Search.Text.ToLower()) || i.Phone.ToLower().Contains(Search.Text.ToLower())).ToList();
        }
        
    }
}
