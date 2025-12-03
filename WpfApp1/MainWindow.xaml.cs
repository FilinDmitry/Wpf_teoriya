using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        double finalValue = 1;
        private void Thumb_OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            Slider slider = (Slider)sender;
            finalValue = slider.Value;

            Shtuk.Text = $"{finalValue} шт";
            summa();
        }

        private int oplata;
        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender; // явное преобразование object в RadioButton
            switch (rb.Content.ToString())
            {
                case "Наличные":
                    oplata = 1;
                    break;
                case "Карта":
                    oplata = 2;
                    break;
                case "Онлайн":
                    oplata = 3;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Оплата {oplata} телефон = {phone} имя = {name} коичество = {finalValue} сумма = {Sun.Text}"); 
        }
        string phone;
        private void TextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]);
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox s = sender as TextBox;
            phone = s.Text;
        }
        string name;
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox s = sender as TextBox;
            name = s.Text;
        }

       
        bool dop_1 = false;
        bool dop_2 = false;
        private void CheckBox_Click(object sender, RoutedEventArgs e) 
        {
            if (dop_1)
            { dop_1 = false; }
            else { dop_1 = true; }
            summa();
        }

        private void CheckBox_Click_2(object sender, RoutedEventArgs e)
        {
            if (dop_2)
            { dop_2 = false; }
            else { dop_2 = true; }
            summa();
        }
        private void summa()
        {
            double sum = 0;
            sum += 500 * finalValue;
            if (dop_1)
            { sum += 100; }
            if (dop_2) { sum += 200; };
            Sun.Text = sum.ToString();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Shtuk != null)
            {
                Slider slider = (Slider)sender;
                finalValue = slider.Value;

                Shtuk.Text = $"{finalValue} шт";
                summa();
            }
        }
        /*
private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
{
TextBox tb = sender as TextBox;
string text = tb.Text; // получаем текст из TextBox

// Получаем информацию об изменениях
foreach (var change in e.Changes)
{
// change.Offset — позиция изменения в тексте
// change.AddedLength — количество добавленных символов
// change.RemovedLength — количество удалённых символов
MessageBox.Show($"Изменение в позиции {change.Offset}");
}
}

private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
{
ComboBox cb = sender as ComboBox;
ComboBoxItem item = cb.SelectedItem as ComboBoxItem;
// item.Content — выбранный элемент
// cb.SelectedIndex — индекс выбора
MessageBox.Show($"Выбран {item.Content.ToString()}.");
}*/
    }
}
