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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        List<string> roles = null;
        List<User> users = Core.Context.User.Where(i => i.RoleID != 1).ToList();
        public AdminPage()
        {
            
            InitializeComponent();
            roles = Core.Context.Role.Select(i => i.Name).Where(i => i != "Администратор").ToList();
            var displayModels = users.Select(u => new UserDisplayModel
            {
                User = u,
                AvailableRoles = roles,
                SelectedRole = u.Role?.Name
            }).ToList();
            
            Users_LB.ItemsSource = displayModels;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new NewUserWindow(roles);
            window.Show();
        }

        private void RoleChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            User user = cb.Tag as User;
            if (user != null)
            {
                MessageBox.Show(user.FIO);
                user.RoleID = cb.SelectedIndex + 2;
                Core.Context.SaveChanges();
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (Users_LB != null)
            {
                var users_lst = users.Where(i => i.FIO.ToLower().Contains(tb.Text.ToLower()));
                var displayModels = users_lst.Select(u => new UserDisplayModel
                {
                    User = u,
                    AvailableRoles = roles,
                    SelectedRole = u.Role?.Name
                }).ToList();
                Users_LB.ItemsSource = displayModels;
            }


        }


    }
}
