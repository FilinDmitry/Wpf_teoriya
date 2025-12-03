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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int a, b;

            if (!int.TryParse(MinRandTextBox.Text, out a) || !int.TryParse(MaxRandTextBox.Text, out b))
            {
                MessageBox.Show("Неправильный ввод", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                MinRandTextBox.Text = ""; // Обращаемся к элементу MinRandTextBox и меняем его Text на пустой
                MaxRandTextBox.Text = ""; // Обращаемся к элементу MaxRandTextBox и меняем его Text на пустой
                return;
            }

            if (a > b)
            {
                int x = a;
                a = b;
                b = x;
            }

            // Обращаемся к элементу OutputTextBlock и меняем его Text на результат случайной генерации числа
            OutputTextBlock.Text = random.Next(a, b).ToString();
        }
    }
}
