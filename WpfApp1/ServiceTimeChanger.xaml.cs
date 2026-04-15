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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ServiceTimeChanger.xaml
    /// </summary>
    public partial class ServiceTimeChanger : Window
    {
        ServiceDisplayModel displayModel;
        public ServiceTimeChanger(ServiceDisplayModel model)
        {
            InitializeComponent();
            displayModel = model;
            DataContext = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime newDate;
            if (DateTime.TryParse(TB.Text, out newDate))
            {
                displayModel.service.Date = newDate;
                Core.Context.SaveChanges();
                MessageBox.Show("Дата записи успешно изменена");
                GetWindow(this).Close();
            }
            else {
                MessageBox.Show("Не удалось преобразовать дату");
            }
        }
    }
}
