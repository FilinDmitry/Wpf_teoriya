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
    /// Логика взаимодействия для SelectServiceTypeWindow.xaml
    /// </summary>
    ///
    
    public partial class SelectServiceTypeWindow : Window
    {
        public ServiceType selected_type;
        List<ServiceType> types;
        public SelectServiceTypeWindow()
        {
            InitializeComponent();
            types = Core.Context.ServiceType.ToList();
            ListBox.ItemsSource = types;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selected_type = ListBox.SelectedItem as ServiceType;
            if (selected_type != null)
            {
                GetWindow(this).Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBox.ItemsSource = types.Where(i => i.Name.ToLower().Contains(Search.Text.ToLower())).ToList();
        }
    }
}
