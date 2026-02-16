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
    /// Логика взаимодействия для ConfirmPage.xaml
    /// </summary>
    public partial class ConfirmPage : Page
    {

        
        public ConfirmPage()
        {
            
            
            InitializeComponent();
            ListBox_Tickets.ItemsSource = Seats.selected_seats;
            film.Text = SelectedSeans.getfilm().Name;
            zal.Text = "Номер зала: " + SelectedSeans.kinozal_id.ToString();
            date.Text = "Дата начала: " + SelectedSeans.Date.ToString().Substring(0, 5);
            time.Text = "Время начала: " + SelectedSeans.Start.ToString().Substring(0, 5);
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Next_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
