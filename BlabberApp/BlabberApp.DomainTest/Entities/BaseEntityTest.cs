using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BaseEntityTest
    {
        [TestMethod]
        public void TestGetSysId()
        {
            // Arrange
            BaseEntity harness = new BaseEntity();
            string expected = harness.getSysID();

            // Act
            string actual = harness.getSysID();

            // Assert
            Assert.AreEqual(actual, expected);
            Assert.IsTrue(harness.getSysID() is string);
        }
        
        [TestMethod]
        public void TestCreatedDttm()
        {
            // Arrange
            BaseEntity Expected = new BaseEntity();

            // Act
            BaseEntity Actual = new BaseEntity();

            // Assert
            Assert.AreEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString() );
        }

        [TestMethod]
        public void TestModifiedDttm()
        {
            // Arrange
            BaseEntity Expected = new BaseEntity();

            // Act
            BaseEntity Actual = new BaseEntity();

            // Assert
            Assert.AreEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }
    }
}