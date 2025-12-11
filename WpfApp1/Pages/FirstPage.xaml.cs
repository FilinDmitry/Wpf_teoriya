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
            PriceCore.price();
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
