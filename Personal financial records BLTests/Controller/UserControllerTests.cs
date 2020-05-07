using Microsoft.VisualStudio.TestTools.UnitTesting;
using Personal_financial_records_BL.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_financial_records_BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var name = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var profession = Guid.NewGuid().ToString();
            var controller = new UserController(name);
            //Act
            controller.SetNewUserData(birthDate, profession);
            var controller2 = new UserController(name);
            //Asset
            Assert.AreEqual(name, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(profession, controller2.CurrentUser.Profession);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var name = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(name);
            //Assert
            Assert.AreEqual(name, controller.CurrentUser.Name);
        }        
    }
}