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
using WpfApp1.Pages.MenegerPages;
namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
            List<string> list = new List<string>()
            {
                "записи", "заказы", "товары", "типы товаров", "производители", "типы услуг"
            };
            ListSelector.ItemsSource = list;
            ListSelector.SelectedIndex = 0;
        }

        private void ListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            switch(cb.SelectedItem.ToString())
            {
                case "записи":
                    ManagerFrame.Navigate(new ManagerServicePage());
                    break;
                case "заказы":
                    ManagerFrame.Navigate(new ManagerOrderPage());
                    break;
                case "товары":
                    ManagerFrame.Navigate(new ManagerTovarPage());
                    break;
                case "типы товаров":
                    ManagerFrame.Navigate(new ManagerTypeTovarPage());
                    break;
                case "производители":
                    ManagerFrame.Navigate(new ManagerManufacturerPage());
                    break;
                case "типы услуг":
                    ManagerFrame.Navigate(new ManagerServiceTypePage());
                    break;
            }
        }
    }
}
