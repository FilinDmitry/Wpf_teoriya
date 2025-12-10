using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    static class Info
    {
        static public MainWindow MVobj { get; set; }
        static public string model {  get; set; }
        static public string engine { get; set; }
        static public string color { get; set; }
        static public string options { get; set; }
        static public string fio { get; set; }
        static public int phone { get; set; }
        static public string email { get; set; }
        static public void show()
        {
            MessageBox.Show($"model = {model} {engine} color = {color}\n options = {options}\n fio = {fio}\n phone = {phone} \n email = {email}");
        }
    }
}
