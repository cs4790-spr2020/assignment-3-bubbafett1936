using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class InMemoryBlabTest {
        private InMemory<Blab> _harness;
        // private string expected;
        // private string actual;

        public InMemoryBlabTest() {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes")
                .Options;

            _harness = new InMemory<Blab>(new ApplicationContext(options) );
        }

        [TestMethod]
        public void TestAddBlab() {
            // Arrange
            Blab Expected = new Blab();
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = "name@email.com";

            // Act
            _harness.Add(Expected);
            Blab Actual = (Blab) _harness.GetAll().GetEnumerator().Current;

            // Assert
            string ex_msg = Expected.Message;
            string ac_msg = Actual.Message;
            Assert.AreEqual(ex_msg, ac_msg, "Blab that is returned is not expected");
        }
        // [TestMethod]
        // public void TestUpdate()
        // {
        //     // Arrange
        //     _harness.Create(new Blab("id new") );
        //     expected = "id updated";

        //     // Act
        //     harness.Update(0, new Blab("id updated") );
        //     actual = harness.Read(0).getSysID();

        //     // Assert
        //     Assert.AreEqual(expected, actual);
        // }
        // [TestMethod]
        // public void TestDelete()
        // {
        //     // Arrange
        //     harness = new InMemory();
        //     harness.Create(new Blab("id deleted") );
        //     harness.Create(new Blab("id remaining") );
        //     expected = "id remaining";

        //     // Act
        //     harness.Delete(0);
        //     actual = harness.Read(0).getSysID();

        //     // Assert
        //     Assert.AreEqual(expected, actual);
        // }
    }
}
