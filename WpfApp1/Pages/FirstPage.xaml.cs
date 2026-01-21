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
            List<Pizza_l> pizzas = new List<Pizza_l>
            {
                new Pizza_l
                {
                    Name = "4 сыра",
                    Price = 450,
                    Description = "Пицца с 4 сырами",
                    Directory = "/Images/p1.jpg"
                },
                new Pizza_l
                {
                    Name = "2 сыра",
                    Price = 350,
                    Description = "Пицца с 4 сырами но дешевле"
                },
                new Pizza_l
                {
                    Name = "Пепперони",
                    Price = 400,
                    Description = "Пицца с колбасой"
                },
                new Pizza_l
                {
                    Name = "Гойда пицца",
                    Price = 650,
                    Description = "Пицца с дорогой колбасой"
                },
                new Pizza_l
                {
                    Name = "4 мяса",
                    Price = 600,
                    Description = "Пицца с 4 видами мяса"
                }
            };
            PizzaListBox.ItemsSource = pizzas;

        }
        
        private void B_click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new SecondPage());
            Pizza_l p = PizzaListBox.SelectedItem as Pizza_l;
            Pizza.price = p.Price;
            Pizza.name = p.Name;
            MainWindow MVobj = (MainWindow)Window.GetWindow(this);
            MVobj.Cena.Text = Pizza.summa_1().ToString();
        }

        private void PizzaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Goida.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var select_item = button.DataContext as Pizza_l; 
        }
    }
}
