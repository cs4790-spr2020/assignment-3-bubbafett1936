using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain;
using BlabberApp.DataStore;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class InMemoryTest
    {
        private InMemory harness;
        private string expected;
        private string actual;
        [TestMethod]
        public void TestCreate()
        {
            // Arrange
            harness = new InMemory();
            expected = "sysID";

            // Act
            harness.Create(new Blab("sysID") );
            actual = harness.Read(0).getSysID();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestUpdate()
        {
            // Arrange
            harness = new InMemory();
            harness.Create(new Blab("id new") );
            expected = "id updated";

            // Act
            harness.Update(0, new Blab("id updated") );
            actual = harness.Read(0).getSysID();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDelete()
        {
            // Arrange
            harness = new InMemory();
            harness.Create(new Blab("id deleted") );
            harness.Create(new Blab("id remaining") );
            expected = "id remaining";

            // Act
            harness.Delete(0);
            actual = harness.Read(0).getSysID();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
