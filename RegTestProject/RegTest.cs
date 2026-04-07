using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WpfApp1;

namespace UnitTestProject
{
    /// <summary>
    /// Класс с тестирование регистрации пользователя
    /// </summary>
    [TestClass]
    public class RegTest
    {
        DateTime validTime = DateTime.Today.AddYears(-20); //Создание валидной даты рождения (20 лет назад)
        /// <summary>
        /// Проверка попытки регистрации с незаполненными полями
        /// </summary>
        [TestMethod]
        public void EmptyReg()
        {
            Assert.IsFalse(User_reg.New_user("", "", "", "", validTime));
        }
        /// <summary>
        /// Проверка регистрации пользователя с датой рождения в будующем
        /// </summary>
        [TestMethod]
        public void RegFutureDatag()
        {
            Assert.IsFalse(User_reg.New_user("BereznevYar", "Yaroslav", "098098098", "ybereza@gmail.com", DateTime.Now.AddDays(3)));
        }
        /// <summary>
        /// Проверка регистрации пользователя которому меньше 12 лет (при необходимости минальный возраст можно изменить, пока что это 0)
        /// </summary>
        [TestMethod]
        public void LessThan12Reg()
        {
            Assert.IsTrue(User_reg.New_user("BereznevYar", "Yaroslav", "098098098", "ybereza@gmail.com", DateTime.Now.AddYears(-8).AddDays(-45)));
        }
        /// <summary>
        /// Попытка регистрации с пробелами в логине и пароле
        /// </summary>
        [TestMethod]
        public void LogWithSpacesReg()
        {
            Assert.IsFalse(User_reg.New_user("Bereznev  Yar  ", "Yaroslav", "098 0 9 8098", "ybereza@gmail.com", validTime));
        }
        /// <summary>
        /// Попытка создания пользователя с уже существующем логином 
        /// </summary>
        [TestMethod]
        public void ExistingUserReg()
        {
            Assert.IsFalse(User_reg.New_user("Dmitry0752", "Дмитрий", "538492394u0", "filin@mail.ru", validTime));
        }
        /// <summary>
        /// Проверка невозможности регистрации с пробелами
        /// </summary>
        [TestMethod]
        public void WhiteSpaceReg()
        {
            Assert.IsFalse(User_reg.New_user("  ", "  ", "  ", "  ", validTime));
        }
        /// <summary>
        /// Проверка наличия валидация email
        /// </summary>
        [TestMethod]
        public void IncorrectEmailReg()
        {
            Assert.IsFalse(User_reg.New_user("Filin", "Oleg", "42343242245", "mc-anon-kip", validTime));
        }
        /// <summary>
        /// Проведение позитивного тестирование на корректную работу функции
        /// </summary>
        [TestMethod]
        public void RegPos()
        {
            
            Assert.IsTrue(User_reg.New_user("EgurnovaA", "Arina", "0912873465", "aegurnova@gmail.com", validTime));
        }
    }
    
}
