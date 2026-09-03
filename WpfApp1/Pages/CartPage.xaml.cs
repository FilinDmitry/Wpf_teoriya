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
using WpfApp1.Windows;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        List<ProductDisplayModel> products;
        public CartPage(List<ProductDisplayModel> displayModels)
        {
            InitializeComponent();
            products = displayModels;
            ListBox.ItemsSource = products;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (products.Count != 0)
            {
                CreateOrderWindow createOrderWindow = new CreateOrderWindow(products, NavigationService.GetNavigationService(this));
                createOrderWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Корзина пустая");
                NavigationService.GoBack();
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                ProductDisplayModel model = ListBox.SelectedItem as ProductDisplayModel;
                ProductWindow productWindow = new ProductWindow(model);
                productWindow.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            products.Remove(button.DataContext as  ProductDisplayModel);
            ListBox.ItemsSource = null;
            ListBox.ItemsSource = products;
        }

        private void Adder_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ProductDisplayModel product = button.DataContext as ProductDisplayModel;
            product.count+=1;
            ListBox.ItemsSource = null;
            ListBox.ItemsSource = products;
        }
    }
}
