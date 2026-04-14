using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp1
{
    static internal class Authorization
    {
        static List<string> list = new List<string>()
            {" " ,"+", "(", ")", "-"};
        static public User cur_user = null;
        static public bool is_auth = false;

        static public string validchars()
        {
            return string.Join(string.Empty, list);
        }
        static public bool User_Check(string phone, string password)
        {
            if (password.Contains(' '))
            {
                MessageBox.Show("Пароль не может содержать пробелы");
                return false;
            }
            phone = phone_clear(phone);
            if (phone.Length != 11)
            {
                MessageBox.Show("Телефон некорректной длины");
                return false;
            }
            User user = Core.Context.User.FirstOrDefault(x => x.Phone == phone && x.Password == password);
            if (user != null)
            {
                if (user.Role.Name == "Заморожен")
                {
                    MessageBox.Show("Ваш аккаунт заморожен администратором");
                }
                cur_user = user;
                is_auth = true;
                return true; 
            }
            else
            {
                MessageBox.Show("Пользователь с такими данными не найден");
                return false;
            }
            

        }

        static public bool CreateUser(string phone, string fio, string password, int role)
        {
            if (password.Contains(' '))
            {
                MessageBox.Show("Пароль не может содержать пробелы");
                return false;
            }
            
            phone = phone_clear(phone);
            if (phone.Length != 11)
            {
                MessageBox.Show("Телефон некорректной длины");
                return false;
            }
            User user = Core.Context.User.FirstOrDefault(x => x.Phone == phone);
            if (user != null)
            {
                MessageBox.Show("Телефон уже зарегестрирован на другого пользователя");
                return false;
            }
            role += 2;
            User new_user = new User()
            { 
                RoleID = role,
                FIO = fio,
                Password = password,
                Phone = phone
            };
            Core.Context.User.Add(new_user);
            Core.Context.SaveChanges();
            MessageBox.Show("Пользователь успешно создан");
            return true;
        }
        static private string phone_clear(string phone)
        {
            phone = phone.Replace("+7", "8");
            phone = phone.Replace("+ 7", "8");
            if (phone[0] == '7')
            {
                phone = "8" + phone.Substring(1);
            }
            foreach (string el in list)
            {
                phone = phone.Replace(el, string.Empty); 
            }
            return phone;
        }

    }
}
