using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        DateTime validTime = DateTime.Today.AddYears(-20);
        [TestMethod]
        public void EmptyReg()
        {
            Assert.IsFalse(User_reg.New_user("", "", "", "", validTime));
        }
        [TestMethod]
        public void FutureDataReg()
        {
            Assert.IsFalse(User_reg.New_user("BereznevYar", "Yaroslav", "098098098", "ybereza@gmail.com", DateTime.Now.AddDays(3)));
        }
        [TestMethod]
        public void LogWithSpacesReg()
        {
            Assert.IsFalse(User_reg.New_user("Bereznev  Yar  ", "Yaroslav", "098 0 9 8098", "ybereza@gmail.com", validTime));
        }
        [TestMethod]
        public void ExistingUserReg()
        {
            Assert.IsFalse(User_reg.New_user("Dmitry0752", "Дмитрий", "538492394u0", "filin@mail.ru", validTime));
        }
        [TestMethod]
        public void WhiteSpaceReg()
        {
            Assert.IsFalse(User_reg.New_user("  ", "  ", "  ", "  ", validTime));
        }
        [TestMethod]
        public void IncorrectEmailReg()
        {
            Assert.IsFalse(User_reg.New_user("Filin", "Oleg", "42343242245", "mc-anon-kip", validTime));
        }
        [TestMethod]
        public void RegPos()
        {
            Assert.IsTrue(User_reg.New_user("EgurnovaA", "Arina", "0912873465", "aegurnova@gmail.com", validTime));
        }
    }
}
