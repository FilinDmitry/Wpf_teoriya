using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    static internal class Authorization
    {
        static List<string> list = new List<string>()
            {" " ,"+", "(", ")", "-"};

        static public string validchars()
        {
            return string.Join(string.Empty, list);
        }
        static public bool User_Check(string phone, string password)
        {
            phone = phone_clear(phone);
            if (phone.Length != 11)
            {
                MessageBox.Show("Телефон некорректной длины");
                return false;
            }

            return true;

        }
        static private string phone_clear(string phone)
        {
            phone = phone.Replace("+7", "8");
            phone = phone.Replace("+ 7", "8");
            foreach (string el in list)
            {
                phone = phone.Replace(el, string.Empty); 
            }
            return phone;
        }

    }
}
