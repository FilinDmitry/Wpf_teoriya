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
    /// Логика взаимодействия для FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        public FilmPage(Film movie)
        {
            
            DataContext = movie;
            InitializeComponent();

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
    }
}
