using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для FilmPage.xaml
    /// </summary>
    public class Seans_Info
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int Kinozal_ID { get; set; }
        public TimeSpan Lenght { get; set; }
    }
    public partial class FilmPage : Page
    {
        
        public FilmPage(Film movie)
        {
            List<Seans> seans_lst_d = Core.Context.Seans.Where(i => i.Film_ID == movie.ID).ToList();
            
            

            var seans_lst = seans_lst_d.Select(i => new Seans_Info {
                ID = i.ID,
                Date = i.StartTime.Date,
                Time = i.StartTime.TimeOfDay,
                Kinozal_ID = i.Kinozal_ID,
                Lenght = i.Lenght
                }
            ).ToList();


            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(seans_lst);
            PropertyGroupDescription groupDescription
                    = new PropertyGroupDescription("Date");
            view.GroupDescriptions.Add(groupDescription);
            view.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));

            DataContext = movie;
            InitializeComponent();
            
            LB_seans.ItemsSource = view;
            var genre = Core.Context.Film_Genre.Where(i => i.Film_ID == movie.ID).Join(
                Core.Context.Genre,
                i => i.Genre_ID,
                j => j.ID,
                (i, j) => j.Name).ToList();
            Genre.Text = String.Join("\n", genre);
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LB_seans_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if (!User_reg.is_reg)
            {
                //MessageBox.Show("Необходимо зарегестрироваться");
                //return;
            }

            Seans_Info SI = LB_seans.SelectedItem as Seans_Info;

            if (SI != null)
            {
                SelectedSeans.setseans(SI.ID, SI.Kinozal_ID, SI.Date, SI.Time);
                NavigationService.Navigate(new FirstZalPage());
            }
        }
    }
}
