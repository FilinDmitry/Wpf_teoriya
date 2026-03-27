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
    /// Логика взаимодействия для RegestrationPage.xaml
    /// </summary>
    public partial class RegestrationPage : Page
    {
        public RegestrationPage()
        {
            InitializeComponent();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            bool reg = User_reg.New_user(lg.Text, imia.Text, ps.Text, pocht.Text, birth.SelectedDate);
            if (reg)
            {
                NavigationService.GoBack();
                NavigationService.GoBack();
                MainWindow mw = MainWindow.GetWindow(this) as MainWindow;
                mw.User_information.Text = User_reg.login;
            }

            
        }
    }
}
