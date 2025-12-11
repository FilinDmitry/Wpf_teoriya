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
    /// Логика взаимодействия для Credit.xaml
    /// </summary>
    public partial class Credit : Page
    {
        public Credit()
        {
            InitializeComponent();
        }
        double finalValue = 12;
        private void B_click(object sender, RoutedEventArgs e)
        {
            
            
            NavigationService.Navigate(new FinalPage());
            Info.MVobj.AddGoida();
            
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Shtuk != null)
            {
                Slider slider = (Slider)sender;
                finalValue = slider.Value;

                Shtuk.Text = $"{finalValue} месяцев";
            }
        }

        private void TextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PriceCore.n = (int)Sl.Value;
            PriceCore.procent = int.Parse(Procent.Text);
            PriceCore.credit(TBVznos, Credit_sum, Month);
        }
    }
}
