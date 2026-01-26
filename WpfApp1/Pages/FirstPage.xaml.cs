using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для FirstPage.xaml
    /// </summary>
    public class Pizza_l
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public string Directory { get; set; }
    }
    public partial class FirstPage : Page
    {
        public FirstPage()
        {
            InitializeComponent();
            List<Tovar> lst = Core.Context.Tovar.ToList();

            PizzaListBox.ItemsSource = lst;

        }

        private void B_click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new SecondPage());
            MainWindow MVobj = (MainWindow)Window.GetWindow(this);
            Info.MW = MVobj;
            Info.summa();
        }

        private void PizzaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Goida.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Tovar select_item = button.DataContext as Tovar;

            Info.cart.Add(select_item);
        }
    }
}
