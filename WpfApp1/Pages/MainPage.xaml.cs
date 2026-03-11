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
            items_changed();
            Saver.IsEnabled = good_assembly();
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
       private decimal choice(ref decimal price, TextBlock textbox, basepart basepart)
        {
            if (basepart != null)
            {
                textbox.Text = $"Выбрано: {basepart.name}";
                price += basepart.price;
            }
            else
            {
                textbox.Text = $"Не выбрано";
            }
            return price;
            
        }

        public void items_changed()
        {
            decimal price = 0;
            choice(ref price, CPU, SelectedComponents.cpu);
            choice(ref price, Case, SelectedComponents.@case);
            choice(ref price, GPU, SelectedComponents.gpu);
            choice(ref price, RAM, SelectedComponents.ram);
            choice(ref price, DISK, SelectedComponents.storagedevice);
            choice(ref price, Motherboard, SelectedComponents.motherboard);
            choice(ref price, COOLER, SelectedComponents.processorcooler);
            choice(ref price, Power, SelectedComponents.powersupply);
            Price.Text = "Цена: " + decimal.Round(price, 2) + " ₪";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Assembly());
        }

        private void Save_assembly(object sender, RoutedEventArgs e)
        {
            if (SelectedComponents.all_component_selected())
            {
                Window wnd = new SaveWindow();
                wnd.Owner = Window.GetWindow(this);
                wnd.ShowDialog();
            }
        }
        private bool good_assembly()
        {
            if (SelectedComponents.all_component_selected())
            {
                return Checkers.FinalCheck();
            }
            return false;
        }
    }
}
