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
    /// Логика взаимодействия для FinalPage.xaml
    /// </summary>
    public partial class FinalPage : Page
    {
        public FinalPage()
        {
            InitializeComponent();
        }

        private void TextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]);

        }
        private void B_click(object sender, RoutedEventArgs e)
        {

            Info.show();
            Application.Current.Shutdown();
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox TxtBox = (TextBox)sender;
            if (Info.all_complited())
            {
                if (Name.Text.Length > 0 && Phone.Text.Length > 0 && email.Text.Length > 0)
                {
                    Info.email = email.Text;
                    Info.phone = Phone.Text;
                    Info.fio = Name.Text;
                    Btn.IsEnabled = true;
                }
                else { Btn.IsEnabled = false; }
            }
        }
    }
}
