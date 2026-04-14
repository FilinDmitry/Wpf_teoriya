using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace WpfApp1
{
    /// <summary>
    /// Класс отвечающий за проверку регистрации и авторизации пользователей
    /// </summary>
    public static class User_reg 
    {
        static public bool is_reg = false; // Переменная которая хранит произведен ли вход в аккаунт
        static public string login; // Переменная хранящая логин
        static public int id; // Переменная хранящая id пользователя
        static public string name; // Переменная хранящая имя пользователя
        private static List<Users> lst_users = Core.Context.Users.ToList(); // Переменная хранящая список пользователей (для проверки
        private static int min_age = 0; // минимальный возраст для регистрации в сервисе
        /// <summary>
        /// Функция проверки строки, на то является ли она корректным email
        /// </summary>
        /// <param name="email">Строка которую необходимо проверить</param>
        /// <returns><see langword="true"/> если email является корректным, иначе <see langword="false"/></returns>
        private static bool Emailvalidation(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }
        /// <summary>
        /// Метод который проверяет параметры регистрации на корректность. <br/>
        /// Если принимаемые параметры корректны, то вызывает <see cref="Update(Users)"></see> а также <see cref="Check_user(string, string)"/> для входа в аккаунт. 
        /// Иначе выдатет окно с предупреждение о некорректном действии 
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="name">ФИО пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="email">email пользователя</param>
        /// <param name="birthday">Дата рождения пользователя</param>
        /// <returns><see langword="true"/> если полученные параметры корректы, <see langword="false"/> если хотя бы один из параметров не соответствует условиям</returns>
        static public bool New_user(string login, string name, string password, string email, DateTime? birthday)
        {
            if (login.Contains(" ") || password.Contains(" ") || email.Contains(" "))
            {
                MessageBox.Show("логин и пароль не могут содержать пробелы");
                return false;
            }

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || birthday == null)
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }
            
            if (DateTime.Now.AddYears(-min_age) < birthday)
            {
                if (DateTime.Now < birthday)
                {
                    MessageBox.Show("Указанна некорректная дата");
                    return false;
                }
                MessageBox.Show($"Для использования сервиса вы должны достигнуть возраста {min_age} лет");
                return false;
            }
            if (!Emailvalidation(email))
            {
                MessageBox.Show("Введен некорректный email");
                return false; 
            }
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
                birthday = birthday ?? DateTime.Today
            };

            Update(user);
            Check_user(login, password);
            return true;
        }
        /// <summary>
        /// Функция для входа в аккаунт
        /// </summary>
        /// <param name="login_">Значения логина для входа</param>
        /// <param name="password">Значения пароля для входа</param>
        /// <returns><see langword="true"/> если вход успешно выполнене, <see langword="false"/> если введены некорректные данные</returns>
        static public bool Check_user(string login_, string password)
        {
            Users u = lst_users.Where(i => i.Login == login_ && i.Passworg == password).FirstOrDefault();
            if (u == null)
            {
                MessageBox.Show("Введен неверный логин или пароль");
                return false;
            }
            else
            {
                MessageBox.Show("Вход успешно выполнен");
                is_reg = true;
                login = u.Login;
                id = u.ID; 
                name = u.Name;
                return true;
            }
        }
        /// <summary>
        /// Создает запись в пользователя в БД
        /// </summary>
        /// <param name="user"></param>
        static private void Update(Users user)
        {
            Core.Context.Users.Add(user);
            Core.Context.SaveChanges();
            lst_users = Core.Context.Users.ToList();
        }
    }
}
