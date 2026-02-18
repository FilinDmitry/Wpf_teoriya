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
            Seats.selected_seats.Clear();
            NavigationService.GoBack();
        }

        private void Next_click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Seats.selected_seats)
            {
                var a = Core.Context.Seans_Seat.First(i => i.ID == item.ID);
                Core.Context.Seans_Seat.Remove(a);
                Core.Context.SaveChanges();
                item.Status = false;
                Core.Context.Seans_Seat.Add(item);
                

                Ticket ticket = new Ticket()
                { 
                    Seans_ID = item.Seans_ID,
                    Seat_ID = item.Seat_ID,
                    Ticket_Price = item.Seat.Kinozal.Kinozal_Rating.Ticket_Price,
                    User_ID = User_reg.id,
                };
                Core.Context.Ticket.Add(ticket);
                
            }
            Core.Context.SaveChanges();
            Seats.selected_seats.Clear();
            MessageBox.Show("Заказ успешно оформлен");
            NavigationService.Navigate(new MainPage());
        }
    }
}
