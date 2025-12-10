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

        private void B_click(object sender, RoutedEventArgs e)
        {
            
            Info.MVobj.AddGoida();
            Frame MF = Info.MVobj.MainFrame;
            options();
            if (MF.CanGoForward)
            {
                MF.GoForward();
                return;
            }
            NavigationService.Navigate(new Third());
        }
        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Info.color = rb.Content.ToString();
        }
        

        private string options()
        {
            string s = "";
            
            List<CheckBox> lst = new List<CheckBox> { cb1, cb2, cb3, cb4, cb5 };
            foreach (CheckBox cb in lst)
            {
                if (cb.IsChecked == true)
                {
                    s += cb.ToString();
                    if (cb == cb1)
                    {
                        Info.Price += 100000;
                    }
                    if (cb == cb2)
                    {
                        Info.Price += 1000000;
                    }
                    if (cb == cb3)
                    {
                        Info.Price += 300000;
                    }
                    if (cb == cb4)
                    {
                        Info.Price *= 3;
                    }
                    if (cb == cb5)
                    {
                        Info.Price *= 2;
                    }
                }
            }
            
            return s;
        }
    }
}
