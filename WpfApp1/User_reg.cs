using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    static internal class User_reg
    {
        static public bool is_reg = false;
        static public string login;
        static public int id;
        static public string name;
        private static List<Users> lst_users = Core.Context.Users.ToList();

        static public bool New_user(string login, string name, string password, string email, DateTime birthday)
        {
            Users u = lst_users.Where(i => i.Login == login).FirstOrDefault();
            if (u != null)
            {
                MessageBox.Show("Такой пользователь уже существует");
                return false;
            }

            Users user  = new Users()
            { 
                Login = login,
                Name = name,
                Passworg = password,
                email = email,
                birthday = birthday
            };

            Core.Context.Users.Add(user);
            return true;
        }

        static public void Check_user(string login, string password)
        {
            Users u = lst_users.Where(i => i.Login == login && i.Passworg == password).FirstOrDefault();
            if (u == null)
            {
                MessageBox.Show("Введен неверный логин или пароль");
                return;
            }
            else
            {
                MessageBox.Show("Вход успешно выполнен");
                is_reg = true;
                login = u.Login;
                id = u.ID; 
                name = u.Name;
            }
        }
    }
}
