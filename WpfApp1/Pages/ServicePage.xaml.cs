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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        Service service;
        public ServicePage(ServiceDisplayModel sdm)
        {
            InitializeComponent();
            DataContext = sdm;
            service = sdm.service;
            Oplata.ItemsSource = Core.Context.PaymentType.Select(i => i.Name).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Oplata.SelectedItem == null)
            {
                MessageBox.Show("Выбирите тип оплаты");
                return;
            }
            PaymentType payment = Core.Context.PaymentType.First(i => i.Name == Oplata.SelectedItem.ToString());
            service.ClientID = Authorization.cur_user.ID;
            service.Comment = Comment.Text;
            service.PaymentTypeID = payment.ID;
            Core.Context.SaveChanges();
            MessageBox.Show("Вы успешно записаны");
            NavigationService.Navigate(new StartPage());
        }
    }
}
