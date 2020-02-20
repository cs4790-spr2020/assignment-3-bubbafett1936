using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain;

namespace BlabberApp.DomainTest
{
    [TestClass]
    public class BlabTest
    {
        private Blab harness;
        private string expected;
        private string actual;
        [TestMethod]
        public void TestSetGetMessage()
        {
            // Arrange
            harness = new Blab();
            expected = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            harness.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            // Act
            actual = harness.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestSetGetUserID()
        {
            // Arrange
            harness = new Blab();
            expected = "f680b92b-9c1a-4341-8192-1ec5d845a4b8";
            harness.UserID = "f680b92b-9c1a-4341-8192-1ec5d845a4b8";
            // Act
            actual = harness.UserID;
            // Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestGetSysID()
        {
            // Arrange
            harness = new Blab("50a88e42-6436-496b-86cb-ea788c346bdc");
            expected = "50a88e42-6436-496b-86cb-ea788c346bdc";
            // Act
            actual = harness.getSysID();
            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
