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
    /// Логика взаимодействия для MasterPage.xaml
    /// </summary>
    public partial class MasterPage : Page
    {
        public MasterPage()
        {
            InitializeComponent();
            List<Service> services = Core.Context.Service.ToList();
            DateTime now = DateTime.Now;
            var displayModels = services.Select(u => new ServiceDisplayModel
            {
                service = u
            }).ToList();
            ListBox.ItemsSource = displayModels;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ServiceDisplayModel item = ListBox.SelectedItem as ServiceDisplayModel;
            if (item != null)
            {
                NavigationService.Navigate(new ServicePageForMaster(item));
            }
        }
    }
}
