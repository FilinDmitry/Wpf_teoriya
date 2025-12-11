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
        static public string model { get; set; } = null;
        static public string engine { get; set; } = null;
        static public string color { get; set; } = null;
        static public string options { get; set; } = "";
        static public string fio { get; set; } = null;
        static public string phone { get; set; } = null;
        static public string email { get; set; } = null;
        
        
        
        static public void show()
        {
            MessageBox.Show($"model = {model} {engine} color = {color}\n{options}\n fio = {fio}\n phone = {phone} \n email = {email} {PriceCore.info()}");
        }
        
        

        static public bool all_complited()
        {
            return model!= null && engine != null && color != null;
        }



    }
}
