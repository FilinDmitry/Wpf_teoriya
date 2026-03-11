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
    /// Логика взаимодействия для SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        public SaveWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Author.Text.Length == 0 || Name.Text.Length == 0)
            { MessageBox.Show("Введите имя и название сборки"); return; }
            GetWindow(this).Close();
            try
            {
                assembly assembly = new assembly()
                { author = Author.Text, name = Name.Text };
                Core.Context.assembly.Add(assembly);
                Core.Context.SaveChanges();
                foreach (basepart item in SelectedComponents.lst)
                {
                    partassembly partassembly = new partassembly()
                    { partid = item.id, assemblyid = assembly.id };
                    Core.Context.partassembly.Add(partassembly);
                }
                Core.Context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
            }
            
        }
    }
}
