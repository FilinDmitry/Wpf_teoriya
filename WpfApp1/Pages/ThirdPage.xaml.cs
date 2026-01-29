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
    /// Логика взаимодействия для ThirdPage.xaml
    /// </summary>
    public partial class ThirdPage : Page
    {


        public ThirdPage()
        {
            InitializeComponent();
            //Zakaz.Text = Info.text_info();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Благодарим за заказ");
            //Info.write_data(TB_fio.Text, TB_adres.Text, TB_pochta.Text);
            Application.Current.Shutdown();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TB_adres.Text.Length > 10 && TB_pochta.Text.Length > 10 && TB_fio.Text.Length > 10)
            {
                Final.IsEnabled = true;
            }
            else
            {
                Final.IsEnabled = false;
            }
        }
    }
}
