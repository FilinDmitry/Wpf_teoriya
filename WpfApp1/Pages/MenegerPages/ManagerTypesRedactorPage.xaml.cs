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
    /// Логика взаимодействия для ManagerTypeTovarPage.xaml
    /// </summary>
    public partial class ManagerTypeTovarPage : Page
    {
        private int lst_var = 0; 
        public ManagerTypeTovarPage(int variant)
            // 1 - тип товаров
            // 2 - производитель
            // 3 - тип услуги
        {
            lst_var = variant;
            InitializeComponent();
            switch (lst_var)
            {
                case 1:
                    ListBox.ItemsSource = Core.Context.ProductType.ToList();
                    break;
                case 2:
                    ListBox.ItemsSource = Core.Context.Manufacturer.ToList();
                    break;
                case 3:
                    ListBox.ItemsSource = Core.Context.ServiceType.ToList();
                    break;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            switch(lst_var)
            {
                case 1:
                    ProductType item = textBox.DataContext as ProductType;
                    item.Name = textBox.Text;
                    Core.Context.SaveChanges();
                    break;
                case 2:
                    Manufacturer item_1 = textBox.DataContext as Manufacturer;
                    item_1.Name = textBox.Text;
                    Core.Context.SaveChanges();
                    break;
                case 3:
                    ServiceType item_2 = textBox.DataContext as ServiceType;
                    item_2.Name = textBox.Text;
                    Core.Context.SaveChanges();
                    break;
            }
        }
    }
}
