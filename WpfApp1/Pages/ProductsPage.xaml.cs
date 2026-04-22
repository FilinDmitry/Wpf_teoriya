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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        List<Product> products;
        List<ProductDisplayModel> displayModels;
        List<ProductDisplayModel> cart = new List<ProductDisplayModel>();
        public ProductsPage()
        {
            InitializeComponent();
            CB_Type.ItemsSource = Core.Context.ProductType.Select(x => x.Name).ToList();
            products = Core.Context.Product.Where(i => !i.IsFreeze).OrderByDescending(i => i.Rating).ToList();
            displayModels = products.Select(i =>
                new ProductDisplayModel() { product = i}
                ).ToList();
            ListBox.ItemsSource = displayModels;
        }

        private void CB_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                filter(CB_Type.SelectedItem?.ToString(), TB_Manufacturer.Text, TB_Name.Text);
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
                filter(CB_Type.SelectedItem?.ToString(), TB_Manufacturer.Text, TB_Name.Text);
            
        }

        private void filter(string Type, string manufacturer, string name)
        {
            ListBox.ItemsSource = null;
            List<ProductDisplayModel> local_prod = displayModels;
            
            if (Type != null)
            {
                local_prod = local_prod.Where(i => i.product.ProductType.Name == Type).ToList();
            }
            if (!string.IsNullOrEmpty(manufacturer))
            {
                local_prod = local_prod.Where(i => i.product.Manufacturer.Name.ToLower() == manufacturer.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(name))
            {
                local_prod = local_prod.Where(i => i.product.Name.ToLower() == name.ToLower()).ToList();
            }
            ListBox.ItemsSource = local_prod;
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
            if (!Authorization.is_auth)
            {
                MessageBox.Show("Сначала необходимо зарегестрироваться");
                NavigationService.Navigate(new Auth());
                return;
            }
            ProductDisplayModel pdm = button.DataContext as ProductDisplayModel;
            displayModels.Remove(pdm);
            cart.Add(pdm);
            filter(CB_Type.SelectedItem?.ToString(), TB_Manufacturer.Text, TB_Name.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Authorization.is_auth)
            {
                MessageBox.Show("Сначала необходимо зарегестрироваться");
                NavigationService.Navigate(new Auth());
                return;
            }
            if (cart.Count == 0)

            { MessageBox.Show("Сначала добавьте хоть 1 товар"); }
            NavigationService.Navigate(new CartPage(cart));
        }
    }
}
