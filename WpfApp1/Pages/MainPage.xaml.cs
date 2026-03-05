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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            List<basepart> list = new List<basepart>(); 
            switch (button.Name)
            {
                case "proc":
                    list = Core.Context.cpu.Cast<basepart>().ToList();
                    break;
                case "plata":
                    list = Core.Context.motherboard.Cast<basepart>().ToList();
                    break;
                case "block":
                    list = Core.Context.powersupply.Cast<basepart>().ToList();
                    break;
                case "corp":
                    list = Core.Context.@case.Cast<basepart>().ToList();
                    break;
                case "video":
                    list = Core.Context.gpu.Cast<basepart>().ToList();
                    break;
                case "oper":
                    list = Core.Context.ram.Cast<basepart>().ToList();
                    break;
                case "disk":
                    list = Core.Context.storagedevice.Cast<basepart>().ToList();
                    break;
                case "cooler":
                    list = Core.Context.processorcooler.Cast<basepart>().ToList();
                    break;
            }
            
            NavigationService.Navigate(new SelectItem(list));
        }
    }
}
