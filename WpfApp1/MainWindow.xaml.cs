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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Cal.BlackoutDates.Add(new CalendarDateRange(new DateTime(2026, 03, 27)));
            Cal.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1)));
        }

        
        

        


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            TB.Text = $"Нажата клавиша {e.Key}";
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            TB.Text = $"Отпущена клавиша {e.Key}";
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendar calendar = sender as Calendar;
            DateTime dateTime = (DateTime)calendar.SelectedDate;
            Year.Text = dateTime.Year.ToString();
            Month.Text = dateTime.Month.ToString();
            DayOfWeek.Text = dateTime.DayOfWeek.ToString();
            Date.Text = dateTime.Date.ToString("dd.MM.yyyy");
        }
    }
}
