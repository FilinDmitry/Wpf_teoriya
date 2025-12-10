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
    /// Логика взаимодействия для FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {
        public FirstPage()
        {
            InitializeComponent();
        }
        
        private void B_click(object sender, RoutedEventArgs e)
        {
            MainWindow MVobj = (MainWindow)Window.GetWindow(this);
            Info.MVobj = MVobj;
            Info.MVobj.AddGoida();
            Frame MF = Info.MVobj.MainFrame;
            switch (Info.model)
            {
                case "Седан (400 000)":
                    Info.Price = 400000;
                    break;
                case "Кроссовер (1 000 000)":
                    Info.Price = 1000000;
                    break;
                case "Купе (600 000)":
                    Info.Price = 600000;
                    break;
                case "Танк (25 000 000)":
                    Info.Price = 25000000;
                    break;
                case "Джип (1 500 000)":
                    Info.Price = 1500000;
                    break;
            }
            switch (Info.engine)
            {
                case "Электрический (x 2)":
                    Info.Price *= 2;
                    break;
                case "Турбореактивный (x 7)":
                    Info.Price *= 7;
                    break;
            }
                if (MF.CanGoForward)
                {
                    MF.GoForward();
                    return;
                }
            NavigationService.Navigate(new SecondPage());
            
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Info.model = rb.Content.ToString();
        }

        private void ToggleButton_OnChecked_2(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Info.engine = rb.Content.ToString();
        }
    }
}
