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
    /// Логика взаимодействия для ServiceUserChanger.xaml
    /// </summary>
    public partial class ServiceUserChanger : Window
    {
        ServiceDisplayModel displayModel;
        List<User> users;
        public ServiceUserChanger(ServiceDisplayModel model)
        {
            InitializeComponent();
            displayModel = model;
            users = Core.Context.User.Where(i  => i.Role.Name == "Клиент").ToList();
            ListBox.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = ListBox.SelectedItem as User;
            if (user != null)
            {
                displayModel.service.User = user;
                
                GetWindow(this).Close();
                MessageBox.Show("Данные записаны успешно");
            }
            else { MessageBox.Show("Произошла ошибка"); }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBox.ItemsSource = users.Where(i => i.FIO.ToLower().Contains(Search.Text.ToLower()) || i.Phone.ToLower().Contains(Search.Text.ToLower())).ToList();
        }
    }
}
