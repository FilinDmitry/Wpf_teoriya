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
    /// Логика взаимодействия для FirstZalPage.xaml
    /// </summary>
    
    public partial class FirstZalPage : Page
    {
        public List<Button> selected_seats = new List<Button>(); 
        public FirstZalPage()
        {
            InitializeComponent();
            Price.Text = Core.Context.Kinozal.First(i => i.ID == SelectedSeans.kinozal_id).Kinozal_Rating.Ticket_Price.ToString() + " ₪"; // Это шекель
            Seats.FindSeats(SelectedSeans.kinozal_id, SelectedSeans.seansID);

            int row = Seats.MaxRow();
            int column = Seats.MaxNum();

            for (int i = 0; i < column + 2; i++)
            {
                for (int j = 1; j < row + 1; j++)
                {
                    RowDefinition rowDefinition = new RowDefinition();
                    rowDefinition.Height = new GridLength(1, GridUnitType.Auto);

                    ColumnDefinition columnDefinition = new ColumnDefinition();
                    columnDefinition.Width = new GridLength(1, GridUnitType.Auto);

                    gridMesta.RowDefinitions.Add(rowDefinition);
                    gridMesta.ColumnDefinitions.Add(columnDefinition);
                    if (i != 0 && i != column + 1)
                    {

                        Seat seat = Seats.lst_seat.FirstOrDefault(s => s.Row == (j + 1) && s.Number == i);
                        bool isActive = Seats.isActive(j, i);
                        Button btn = new Button();
                        btn.Content = i.ToString();
                        btn.Width = 30;
                        btn.Height = 30;
                        btn.Foreground = Brushes.White;
                        btn.BorderThickness = new Thickness(0);
                        btn.Margin = new Thickness(5);
                        if (isActive)
                        {
                            btn.Background = Brushes.Beige;
                            btn.Foreground = Brushes.Black;
                            btn.Click += Btn_Click;
                        }
                        else
                        {
                            btn.Background = Brushes.Gray;
                            btn.Foreground = Brushes.Black;
                        }

                        Grid.SetColumn(btn, i);
                        Grid.SetRow(btn, j);


                        gridMesta.Children.Add(btn);
                    }
                    else
                    {
                        TextBlock tb = new TextBlock();
                        tb.Text = j.ToString();
                        tb.Margin = new Thickness(5);

                        tb.HorizontalAlignment = HorizontalAlignment.Center;
                        tb.VerticalAlignment = VerticalAlignment.Center;
                        Grid.SetColumn(tb, i);
                        Grid.SetRow(tb, j);


                        gridMesta.Children.Add(tb);
                    }
                }
            }
        }




        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            
            if (!selected_seats.Contains(btn))
            {
                btn.Background = Brushes.Magenta;
                Seats.Add(Grid.GetRow(btn), Grid.GetColumn(btn));
                selected_seats.Add(btn);
            }
            else
            {
                btn.Background = Brushes.Beige;
                Seats.Del(Grid.GetRow(btn), Grid.GetColumn(btn));
                selected_seats.Remove(btn);
            }
        }
            

        private void Back_click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Next_click(object sender, RoutedEventArgs e)
        {
            if (Seats.isTicket())
            {
                NavigationService.Navigate(new ConfirmPage());
            }
            else
            {
                MessageBox.Show("Необходимо выбрать места");
            }
        }
    }
}
