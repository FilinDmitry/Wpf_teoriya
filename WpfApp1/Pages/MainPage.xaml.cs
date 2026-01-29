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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static List<Film> Film_lst = Core.Context.Film.ToList();
        public static List<string> Sorting = new List<string> { "Названию", "Рейтингу" };
        public MainPage()
        {
            InitializeComponent();
            ListBox_FilmsCatalog.ItemsSource = Film_lst;
            ComboBox_Sort.ItemsSource = Sorting;
            ComboBox_Sort.SelectedIndex = 0;
        }

        private void FilmsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            ListBox_FilmsCatalog.ItemsSource = Film_lst.Where(i => i.Name.ToLower().Contains(TextBox_Search.Text.ToLower()));
        }

        private void SortByCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox_Sort.SelectedItem as string)
            {
                case "Названию":
                    ListBox_FilmsCatalog.ItemsSource = Film_lst.OrderBy(i => i.Name);
                    break;
                case "Рейтингу":
                    ListBox_FilmsCatalog.ItemsSource = Film_lst.OrderByDescending(i => i.Rating);
                    break;
                default:
                    ListBox_FilmsCatalog.ItemsSource = Film_lst.OrderBy(i => i.Name);
                    break;
            }

        }

        private void TextBox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBox_FilmsCatalog.ItemsSource = Film_lst.Where(i => i.Name.ToLower().Contains(TextBox_Search.Text.ToLower()));
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            if (User_reg.is_reg)
            {
                NavigationService.Navigate(new ProfilePage());
            }
            else 
            {
                NavigationService.Navigate(new EnterPage());
            }
        }
    }
}
