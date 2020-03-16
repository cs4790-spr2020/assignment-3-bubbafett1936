using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest
{
    [TestClass]
    public class BlabTest
    {
        [TestMethod]
        public void Test_SetGetMessage()
        {
            // Arrange
            Blab harness = new Blab();
            string expected = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            harness.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

            // Act
            string actual = harness.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SetGetUserID()
        {
            // Arrange
            Blab harness = new Blab();
            string expected = "name@email.com";
            harness.UserID = "name@email.com";

            // Act
            string actual = harness.UserID;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_GetSysID()
        {
            // Arrange
            Blab harness = new Blab();
            string expected = harness.getSysID();

            // Act
            string actual = harness.getSysID();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(harness.getSysID() is string);
        }
        
        [TestMethod]
        public void TestDTTM()
        {
            // Arrange
            Blab Expected = new Blab();

            // Act
            Blab Actual = new Blab();
            
            // Assert
            Assert.AreEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }
    }
}
