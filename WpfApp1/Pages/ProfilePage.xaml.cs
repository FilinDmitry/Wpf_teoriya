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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            ListBox_Tickets.ItemsSource = Core.Context.Ticket.Where(i => i.User_ID == User_reg.id).ToList();
            ID.Text = "ID:" + User_reg.id.ToString();
            Name.Text = User_reg.name;
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
