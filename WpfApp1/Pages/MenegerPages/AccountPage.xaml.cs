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

namespace WpfApp1.Pages.MenegerPages
{
    /// <summary>
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
            ListBoxService.ItemsSource = Core.Context.Service.Where(i => i.ClientID == Authorization.cur_user.ID).Select(u => new ServiceDisplayModel
            {
                service = u
            }).ToList();
            ListBoxOrder.ItemsSource = Core.Context.Order.Where(i => i.UserID == Authorization.cur_user.ID).ToList();
        }
    }
}
