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
    /// Логика взаимодействия для ManagerOrderPage.xaml
    /// </summary>
    public partial class ManagerOrderPage : Page
    {
        public ManagerOrderPage()
        {
            InitializeComponent();
            ListBox.ItemsSource = Core.Context.Order.ToList();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            Order order = checkBox.DataContext as Order;
            order.IsComplete = (bool)checkBox.IsChecked;
            Core.Context.SaveChanges();
        }
    }
}
