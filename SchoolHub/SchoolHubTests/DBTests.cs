using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolHub.Infrastructure.Containers;

namespace SchoolHubTests
{
    [TestClass]
    public class DBTests
    {
        [TestMethod]
        public void TestGetUser()
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = new User();
            user = db.GetUserByUsernamePassword("Tester", "test");
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void TestInsertUser()
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = new User();
            string password = "test";
            user.Username = "Tester2";
            user.FirstName = "Testo";
            user.LastName = "Testerson";
            user.Email = "test@testmail.com";
            user.RoleId = 1;
            string response = db.AddUser(user, password);
            Assert.AreEqual("A user with the username Tester2 already exists.", response);
        }
    }
}
