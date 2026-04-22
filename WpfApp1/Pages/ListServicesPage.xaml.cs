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
    /// Логика взаимодействия для ListServicesPage.xaml
    /// </summary>
    public partial class ListServicesPage : Page
    {
        List<Service> services;
        List<ServiceDisplayModel> serviceDisplays;
        public ListServicesPage(ServiceType st)
        {
            
            InitializeComponent();
            services = Core.Context.Service.Where(i => i.ServiceType.ID == st.ID && i.User == null).ToList();
            serviceDisplays = services.Select(u => new ServiceDisplayModel
            {
                service = u
            }).ToList();
            ListBox.ItemsSource = serviceDisplays;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ServiceDisplayModel sdm = ListBox.SelectedItem as ServiceDisplayModel;
            NavigationService.Navigate(new ServicePage(sdm));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter(MasterTB.Text, DatePicker.SelectedDate);
            
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker dt = sender as DatePicker;
            Filter(MasterTB.Text, dt.SelectedDate);
        }
        private void Filter(string master, DateTime? date)
        {
            List<ServiceDisplayModel> serv = serviceDisplays;
            if (master != null)
            {
               serv = serv.Where(i => i.service.User1.FIO.ToLower().Contains(master.ToLower())).ToList();
            }
            if (date != null)
            { 
                serv = serv.Where(i => i.service.Date.Date == date).ToList();
            }
            ListBox.ItemsSource= serv;
        }
    }
}
