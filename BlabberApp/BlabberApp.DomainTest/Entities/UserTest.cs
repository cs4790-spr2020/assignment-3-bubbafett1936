using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void Test_SetGetEmail()
        {
            // Arrange
            User harness = new User();
            string expected = "name@email.com";
            harness.Email = "name@email.com";

            // Act
            string actual = harness.Email;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_GetSysID()
        {
            // Arrange
            User harness = new User();
            string expected = harness.getSysID();

            // Act
            string actual = harness.getSysID();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(harness.getSysID() is string);
        }
    }
}