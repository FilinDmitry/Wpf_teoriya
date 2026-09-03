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
using WpfApp1.Windows;

namespace WpfApp1.Pages.MenegerPages
{
    /// <summary>
    /// Логика взаимодействия для ManagerServicePage.xaml
    /// </summary>
    public partial class ManagerServicePage : Page
    {
        public ManagerServicePage()
        {
            InitializeComponent();
            List<Service> services = Core.Context.Service.Where(i => i.Date >= DateTime.Now).ToList();
            DateTime now = DateTime.Now;
            var displayModels = services.Select(u => new ServiceDisplayModel
            {
                service = u
            }).ToList();
            ListBox.ItemsSource = displayModels;
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ServiceDisplayModel sdm = button.DataContext as ServiceDisplayModel;
            ServiceTimeChanger servicechange = new ServiceTimeChanger(sdm);
            servicechange.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ServiceDisplayModel sdm = button.DataContext as ServiceDisplayModel;
            Core.Context.Service.Remove(sdm.service);
            Core.Context.SaveChanges();
            List<Service> services = Core.Context.Service.ToList();
            DateTime now = DateTime.Now;
            var displayModels = services.Select(u => new ServiceDisplayModel
            {
                service = u
            }).ToList();
            ListBox.ItemsSource = displayModels;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ServiceCreateNewWindow @new = new ServiceCreateNewWindow();
            @new.Show();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ServiceDisplayModel sdm = button.DataContext as ServiceDisplayModel;
            ServiceUserChanger servicechange = new ServiceUserChanger(sdm);
            servicechange.Show();

        }
    }
}
