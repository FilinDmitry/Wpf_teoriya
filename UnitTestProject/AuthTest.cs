using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1;

namespace UnitTestProject
{
    /// <summary>
    /// Класс тестирования авторизации пользователя
    /// </summary>
    [TestClass]
    public class AuthTest
    {
        /// <summary>
        /// Проверка на вход с пустыми полями
        /// </summary>
        [TestMethod]
        public void EmptyAuth()
        {
            Assert.IsFalse(User_reg.Check_user("", ""));
        }
        /// <summary>
        /// Проверка на вход с некорректным логином/паролем
        /// </summary>
        [TestMethod]
        public void WrongUserDataAuth()
        {
            Assert.IsFalse(User_reg.Check_user("OlegT", "Tinkoff123"));
            Assert.IsFalse(User_reg.Check_user("Dmitry0752", "7654321"));
            Assert.IsFalse(User_reg.Check_user("Goida", "1234"));
        }
        /// <summary>
        /// Проверка позитивного сценария работы функции
        /// </summary>
        [TestMethod]
        public void AuthPos1()
        {
            Assert.IsTrue(User_reg.Check_user("Dmitry0752", "12345678"));
            Assert.IsTrue(User_reg.Check_user("Goida", "Goida"));
        }
        
    }   
}
