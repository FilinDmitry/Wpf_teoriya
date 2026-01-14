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
            List<string> list = new List<string>
            {
                "сыр +50₽", "бекон +80₽", "грибы +40₽"
            };
            Dop.ItemsSource = list;

        }

        private void B_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ThirdPage());
            MainWindow MVobj = (MainWindow)Window.GetWindow(this);
            MVobj.Cena.Text = Pizza.summa_2().ToString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
                RadioButton s = sender as RadioButton;
                Pizza.size = s.Content.ToString();
                MainWindow MVobj = (MainWindow)Window.GetWindow(this);
            if (MVobj != null)
            {
                MVobj.Cena.Text = Pizza.summa_2().ToString();
            }
        }

        private void Dop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = Dop.SelectedIndex;
            switch (i)
            {
                case 0:
                    Pizza.cheese += 1;
                    break;
                case 1:
                    Pizza.becon += 1;
                    break;
                case 2:
                    Pizza.mushroom += 1;
                    break;
            }
            MainWindow MVobj = (MainWindow)Window.GetWindow(this);
            
                MVobj.Cena.Text = Pizza.summa_2().ToString();
            

        }
    }
}
