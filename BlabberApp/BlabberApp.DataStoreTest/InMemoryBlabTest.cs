using BlabberApp.DataStore;
using BlabberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class InMemoryBlabTest {
        [TestMethod]
        public void Test_AddBlab() {
            // Arrange
            InMemory<Blab> _addblabharness =
                new InMemory<Blab>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Add_Blab")
                        .Options));

            Blab Expected = new Blab();
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = "name@email.com";
            _addblabharness.Add(Expected);

            // Act
            IEnumerator<Blab> add_blab = _addblabharness.GetAll().GetEnumerator();
            add_blab.MoveNext();
            Blab Actual = add_blab.Current;

            // Assert
            Assert.AreEqual(Expected.Message, Actual.Message, "Blab message that is returned is not expected");
            Assert.AreEqual(Expected.UserID, Actual.UserID, "Blab user id that is returned is not expected");
        }

        [TestMethod]
        public void Test_UpdateBlab() {
            // Arrange
            InMemory<Blab> _updateblabharness =
                new InMemory<Blab>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Update_Blab")
                        .Options));

            Blab Expected = new Blab();
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = "name@email.com";
            _updateblabharness.Add(Expected);
            IEnumerator<Blab> update_blab = _updateblabharness.GetAll().GetEnumerator();
            update_blab.MoveNext();
            update_blab.Current.Message = "updated";
            update_blab.Current.UserID = "updated@email.com";

            // Act
            _updateblabharness.Update(update_blab.Current);
            IEnumerator<Blab> update_blab_updated = _updateblabharness.GetAll().GetEnumerator();
            update_blab_updated.MoveNext();
            Blab Actual = update_blab_updated.Current;

            // Assert
            Assert.AreEqual("updated", Actual.Message, "Blab message that is returned is not expected");
            Assert.AreEqual("updated@email.com", Actual.UserID, "Blab user id that is returned is not expected");
        }

        [TestMethod]
        public void Test_RemoveBlab() {
            // Arrange
            InMemory<Blab> _removeblabharness =
                new InMemory<Blab>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Remove_Blab")
                        .Options));

            Blab Expected = new Blab();
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = "name@email.com";
            _removeblabharness.Add(Expected);
            Blab Expected_Second = new Blab();
            Expected_Second.Message = "second message";
            Expected_Second.UserID = "second@email.com";
            _removeblabharness.Add(Expected_Second);
            IEnumerator<Blab> remove_blab = _removeblabharness.GetAll().GetEnumerator();
            remove_blab.MoveNext();

            // Act
            _removeblabharness.Remove(remove_blab.Current);
            IEnumerator<Blab> remove_blab_removed = _removeblabharness.GetAll().GetEnumerator();
            remove_blab_removed.MoveNext();
            Blab Actual_Deleted = remove_blab_removed.Current;

            // Assert
            Assert.AreEqual(Expected_Second.Message, Actual_Deleted.Message, "Blab message that is returned is not expected");
            Assert.AreEqual(Expected_Second.UserID, Actual_Deleted.UserID, "Blab user id that is returned is not expected");
        }

        [TestMethod]
        public void Test_GetAllBlabs() {
            // Arrange
            InMemory<Blab> _getallblabsharness =
                new InMemory<Blab>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Get_All_Blabs")
                        .Options));

            Blab Expected = new Blab();
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = "name@email.com";
            _getallblabsharness.Add(Expected);
            Blab Expected_Second = new Blab();
            Blab Expected_Third = new Blab();
            Expected_Second.Message = "second message";
            Expected_Second.UserID = "second@email.com";
            Expected_Third.Message = "third message";
            Expected_Third.UserID = "third@email.com";
            _getallblabsharness.Add(Expected_Second);
            _getallblabsharness.Add(Expected_Third);

            // Act
            IEnumerator<Blab> all_blabs = _getallblabsharness.GetAll().GetEnumerator();

            // Assert
            all_blabs.MoveNext();
            Assert.AreEqual(Expected.Message, all_blabs.Current.Message, "Blab first message that is returned is not expected");
            Assert.AreEqual(Expected.UserID, all_blabs.Current.UserID, "Blab first user id that is returned is not expected");
            all_blabs.MoveNext();
            Assert.AreEqual(Expected_Second.Message, all_blabs.Current.Message, "Blab second message that is returned is not expected");
            Assert.AreEqual(Expected_Second.UserID, all_blabs.Current.UserID, "Blab second user id that is returned is not expected");
            all_blabs.MoveNext();
            Assert.AreEqual(Expected_Third.Message, all_blabs.Current.Message, "Blab third message that is returned is not expected");
            Assert.AreEqual(Expected_Third.UserID, all_blabs.Current.UserID, "Blab third user id that is returned is not expected");
        }
        
        [TestMethod]
        public void Test_GetBySysIDSuccess() {
            // Arrange
            InMemory<Blab> _getbysysidharness =
                new InMemory<Blab>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Get_By_Sys_ID")
                        .Options));

            Blab Expected = new Blab();
            Blab Unexpected = new Blab();
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = "name@email.com";
            Unexpected.Message = "This is incorrect";
            Unexpected.UserID = "incorrect@email.com";
            _getbysysidharness.Add(Expected);
            _getbysysidharness.Add(Unexpected);

            // Act
            Blab Actual = (Blab) _getbysysidharness.GetBySysID(Expected.SysID);

            // Assert
            Assert.AreEqual(Expected.SysID, Actual.SysID, "Blab message that is returned is not expected");
            Assert.AreEqual(Expected.Message, Actual.Message, "Blab message that is returned is not expected");
            Assert.AreEqual(Expected.UserID, Actual.UserID, "Blab user id that is returned is not expected");
        }
        
        [TestMethod]
        public void Test_GetByUserIDSuccess() {
            // Arrange
            InMemory<Blab> _getbyuseridharness =
                new InMemory<Blab>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Get_By_User_ID")
                        .Options));

            Blab Expected = new Blab();
            Blab Unexpected = new Blab();
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = "name@email.com";
            Unexpected.Message = "This is incorrect";
            Unexpected.UserID = "incorrect@email.com";
            _getbyuseridharness.Add(Expected);
            _getbyuseridharness.Add(Unexpected);

            // Act
            IEnumerator<KeyValuePair<string,Blab>> Actual = _getbyuseridharness.GetByUserID(Expected.UserID).GetEnumerator();

            // Assert
            Actual.MoveNext();
            Assert.AreEqual(Expected.Message, Actual.Current.Value.Message, "Blab message that is returned is not expected");
        }
    }
}
