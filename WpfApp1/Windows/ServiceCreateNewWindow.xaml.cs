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
using System.Windows.Shapes;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceCreateNewWindow.xaml
    /// </summary>
    
    public partial class ServiceCreateNewWindow : Window
    {
        User master;
        ServiceType serviceType;
        public ServiceCreateNewWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceNew serviceNew = new ServiceNew();
            serviceNew.ShowDialog();
            master = serviceNew.selected_user;
            TB_Master.Text = master.FIO;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SelectServiceTypeWindow serviceNew = new SelectServiceTypeWindow();
            serviceNew.ShowDialog();
            serviceType = serviceNew.selected_type;
            TB_Type.Text = serviceType.Name;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            if (!DateTime.TryParse(Date.Text, out dt))
            {
                MessageBox.Show("Некоректное DateTime");
                return;
            }
            Decimal d;
            if (!Decimal.TryParse(Price.Text, out d))
            {
                MessageBox.Show("Некорректная цена");
                return;
            }
                Service service = new Service()
                {
                    ServiceTypeID = serviceType.ID,
                    MasterID = master.ID,
                    Price = d,
                    Date = dt
                };
            
        }
    }
}
