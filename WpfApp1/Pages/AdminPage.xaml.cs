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
        public List<String> CBSource { get; set; }
        public AdminPage()
        {
            CBSource = Core.Context.Role.Select(i => i.Name).Where(i => i != "Администратор").ToList();
            this.DataContext = this;
            InitializeComponent();
            Users_LB.ItemsSource = Core.Context.User.Where(i => i.RoleID != 1).ToList();
            
        }

        private void RoleSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem != null && Users_LB != null)
            { Users_LB.ItemsSource = Core.Context.User.Where(i => i.Role.Name == cb.SelectedItem.ToString()).ToList(); }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new NewUserWindow(CBSource);
            window.Show();
        }

        /*Button button = sender as Button;
        Tovar select_item = button.DataContext as Tovar;

        Info.cart.Add(select_item);
        */

    }
}
