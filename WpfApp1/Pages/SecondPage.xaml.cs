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
    /// Логика взаимодействия для SecondPage.xaml
    /// </summary>

    public partial class SecondPage : Page
    {
        public SecondPage()
        {
            InitializeComponent();

           
        }
/*
        private void WTF()
        {
            CartListBox.ItemsSource = null;
            CartListBox.ItemsSource = Info.cart;
        }
        private void B_click(object sender, RoutedEventArgs e)
        {
            if (Info.cart.Count > 0)
            {
                NavigationService.Navigate(new ThirdPage());
            }
            else
            {
                MessageBox.Show("Необходжимо добавить товар в корзину");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Tovar select_item = button.DataContext as Tovar;

            Info.cart.Remove(select_item);
            
            Info.summa();
            
            WTF();
        }

        */
    }
}
