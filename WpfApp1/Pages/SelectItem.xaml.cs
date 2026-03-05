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
    /// Логика взаимодействия для SelectItem.xaml
    /// </summary>
    public partial class SelectItem : Page
    {
        public SelectItem(List<basepart> item_lst)
        {
            InitializeComponent();
            CB_proiz.ItemsSource = Core.Context.manufacturer.Select(i => i.name).ToList();
            LB_main.ItemsSource = item_lst;
        }

        private void CB_proiz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TB_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
