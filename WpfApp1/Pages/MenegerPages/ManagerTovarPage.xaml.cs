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

namespace WpfApp1.Pages.MenegerPages
{
    /// <summary>
    /// Логика взаимодействия для ManagerTovarPage.xaml
    /// </summary>
    public partial class ManagerTovarPage : Page
    {
        List<Product> products;
        public ManagerTovarPage()
        {
            InitializeComponent();
            products = Core.Context.Product.ToList();
            ListBox.ItemsSource = products;
        }

        private void TovarFreeze_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            Product prod = checkBox.DataContext as Product;
            prod.IsFreeze = (bool)checkBox.IsChecked;
            Core.Context.SaveChanges();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tBox = sender as TextBox;
            int d;
            if (!int.TryParse(tBox.Text, out d))
            {
                MessageBox.Show("Введите корректное значение скидки");
                return;
            }
            if (d >= 100)
            {
                MessageBox.Show("Введите значение скидки <100");
                return;
            }
            Product prod = tBox.DataContext as Product;
            prod.Discount = d;
            Core.Context.SaveChanges();
            

        }

        private void DiscoundFreeze_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            Product prod = checkBox.DataContext as Product;
            prod.IsFreezeDiscount = (bool)checkBox.IsChecked;
            Core.Context.SaveChanges();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox tBox = sender as TextBox;
            Product prod = tBox.DataContext as Product;
            prod.Description = tBox.Text;
            Core.Context.SaveChanges();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]);
        }
    }
}
