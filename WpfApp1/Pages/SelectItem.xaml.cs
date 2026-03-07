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
        List<basepart> lst_basepart;
        List<basepart> lst_cur;
        public SelectItem(List<basepart> item_lst)
        {
            lst_basepart = item_lst;
            lst_cur = item_lst;
            InitializeComponent();
            CB_proiz.ItemsSource = Core.Context.manufacturer.Select(i => i.name).ToList();
            LB_main.ItemsSource = item_lst;
            
        }

        private void CB_proiz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            set_filters();
        }

        private void TB_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            set_filters();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            CB_proiz.SelectedItem = null;
            TB_search.Text = "";
            LB_main.ItemsSource = lst_basepart;
            lst_cur = lst_basepart;
        }

        private void set_filters()
        {
            List<basepart> filter = new List<basepart>();
            if (CB_proiz.SelectedItem != null)
            {
                 filter = lst_cur.Where(i => i.manufacturer.name == CB_proiz.SelectedItem.ToString()
                &&
                i.name.ToLower().Contains(TB_search.Text.ToLower())).ToList();
                
            }
            else
            {
                filter = lst_cur.Where(i => i.name.ToLower().Contains(TB_search.Text.ToLower())).ToList();
            }
            LB_main.ItemsSource = filter;
        }
    }
}
