using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1;

namespace UnitTestProject
{
    [TestClass]
    public class AuthTest
    {
        [TestMethod]
        public void EmptyAuth()
        {
            Assert.IsFalse(User_reg.Check_user("", ""));
        }
        [TestMethod]
        public void WrongUserDataAuth()
        {
            Assert.IsFalse(User_reg.Check_user("OlegT", "Tinkoff123"));
            Assert.IsFalse(User_reg.Check_user("Dmitry0752", "7654321"));
            Assert.IsFalse(User_reg.Check_user("Goida", "1234"));
        }
        [TestMethod]
        public void AuthPos1()
        {
            Assert.IsTrue(User_reg.Check_user("Dmitry0752", "12345678"));
        }
        [TestMethod]
        public void AuthPos2()
        {
            Assert.IsTrue(User_reg.Check_user("Goida", "Goida"));
        }
    }   
}
