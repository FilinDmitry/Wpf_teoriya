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
using WpfApp1.Pages.MenegerPages;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
           
            if (Authorization.is_auth)
            {
                Bt.Content = "Аккаунт";
            }
            ListBox.ItemsSource = Core.Context.ServiceType.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Authorization.is_auth)
            {
                NavigationService.Navigate(new Auth());
            }
            
            else
            {
                NavigationService.Navigate(new AccountPage());
            }
        }

        private void Button_Tovar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ServiceType st = ListBox.SelectedItem as ServiceType;
            if ( st != null)
            {
                NavigationService.Navigate(new ListServicesPage(st));
            }
           
        }
    }
}
