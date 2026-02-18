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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            User u = new User()
            {
                FirstName = "Максим",
                MiddleName = "Олегович",
                LastName = "Гордов",
                Age = 22
            };
            User u_1 = new User()
            {
                FirstName = "Владимир",
                MiddleName = "Владимирович",
                LastName = "Горланов",
                Age = 23
            };
            List<User> lst = new List<User>() { u, u_1};
            InitializeComponent();
            

        }

    }
}
