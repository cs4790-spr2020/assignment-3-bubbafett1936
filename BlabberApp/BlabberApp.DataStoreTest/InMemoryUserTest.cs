using BlabberApp.DataStore;
using BlabberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class InMemoryUserTest {
        [TestMethod]
        public void Test_AddUser() {
            // Arrange
            InMemory<User> _adduserharness =
                new InMemory<User>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Add_User")
                        .Options));

            User Expected = new User();
            Expected.Email = "name@email.com";

            // Act
            _adduserharness.Add(Expected);
            IEnumerator<User> add_user = _adduserharness.GetAll().GetEnumerator();
            add_user.MoveNext();
            User Actual = add_user.Current;

            // Assert
            Assert.AreEqual(Expected.Email, Actual.Email, "Blab user email that is returned is not expected");
            Assert.AreEqual(Expected.RegisterDTTM, Actual.RegisterDTTM, "Blab user register dttm that is returned is not expected");
        }

        [TestMethod]
        public void Test_UpdateEmail() {
            // Arrange
            InMemory<User> _updateuserharness =
                new InMemory<User>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Update_User")
                        .Options));

            User Expected = new User();
            Expected.Email = "name@email.com";
            _updateuserharness.Add(Expected);
            IEnumerator<User> update_user = _updateuserharness.GetAll().GetEnumerator();
            update_user.MoveNext();
            update_user.Current.Email = "updated@email.com";

            // Act
            _updateuserharness.Update(update_user.Current);
            IEnumerator<User> update_user_updated = _updateuserharness.GetAll().GetEnumerator();
            update_user_updated.MoveNext();
            User Actual_Updated = update_user_updated.Current;

            // Assert
            Assert.AreEqual(Expected.Email, Actual_Updated.Email, "Blab user email that is returned is not expected");
            Assert.AreEqual(Expected.RegisterDTTM, Actual_Updated.RegisterDTTM, "Blab user register dttm that is returned is not expected");
        }
        
        [TestMethod]
        public void Test_RemoveUser()
        {
            // Arrange
            InMemory<User> _removeuserharness =
                new InMemory<User>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Remove_User")
                        .Options));

            User Expected = new User();
            Expected.Email = "name@email.com";
            _removeuserharness.Add(Expected);
            User Expected_Second = new User();
            Expected_Second.Email = "second@email.com";
            _removeuserharness.Add(Expected_Second);
            IEnumerator<User> remove_user = _removeuserharness.GetAll().GetEnumerator();
            remove_user.MoveNext();

            // Act
            _removeuserharness.Remove(remove_user.Current);
            IEnumerator<User> remove_user_deleted = _removeuserharness.GetAll().GetEnumerator();
            remove_user_deleted.MoveNext();
            User Actual_Deleted = remove_user_deleted.Current;

            // Assert
            Assert.AreEqual(Expected_Second.Email, Actual_Deleted.Email, "Blab user email that is returned is not expected");
            Assert.AreEqual(Expected_Second.RegisterDTTM, Actual_Deleted.RegisterDTTM, "Blab user register dttm that is returned is not expected");
        }
        
        [TestMethod]
        public void Test_GetAllUsers()
        {
            // Arrange
            InMemory<User> _getallusersharness =
                new InMemory<User>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Get_All_Users")
                        .Options));

            User Expected_First = new User();
            User Expected_Second = new User();
            User Expected_Third = new User();
            Expected_First.Email = "first@email.com";
            Expected_Second.Email = "second@email.com";
            Expected_Third.Email = "third@email.com";
            _getallusersharness.Add(Expected_First);
            _getallusersharness.Add(Expected_Second);
            _getallusersharness.Add(Expected_Third);

            // Act
            IEnumerator<User> all_users = _getallusersharness.GetAll().GetEnumerator();

            // Assert
            all_users.MoveNext();
            Assert.AreEqual(Expected_First.Email, all_users.Current.Email, "Blab user email that is returned is not expected");
            Assert.AreEqual(Expected_First.RegisterDTTM, all_users.Current.RegisterDTTM, "Blab user register dttm that is returned is not expected");
            all_users.MoveNext();
            Assert.AreEqual(Expected_Second.Email, all_users.Current.Email, "Blab user email that is returned is not expected");
            Assert.AreEqual(Expected_Second.RegisterDTTM, all_users.Current.RegisterDTTM, "Blab user register dttm that is returned is not expected");
            all_users.MoveNext();
            Assert.AreEqual(Expected_Third.Email, all_users.Current.Email, "Blab user email that is returned is not expected");
            Assert.AreEqual(Expected_Third.RegisterDTTM, all_users.Current.RegisterDTTM, "Blab user register dttm that is returned is not expected");
        }
        
        [TestMethod]
        public void Test_GetBySysIDSuccess() {
            // Arrange
            InMemory<User> _getbysysidharness =
                new InMemory<User>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Get_By_Sys_ID")
                        .Options));

            User Expected = new User();
            User Unexpected = new User();
            Expected.Email = "name@email.com";
            Unexpected.Email = "incorrect@email.com";
            _getbysysidharness.Add(Expected);
            _getbysysidharness.Add(Unexpected);

            // Act
            User Actual = (User) _getbysysidharness.GetBySysID(Expected.SysID);

            // Assert
            Assert.AreEqual(Expected.Email, Actual.Email, "Blab user email that is returned is not expected");
            Assert.AreEqual(Expected.RegisterDTTM, Actual.RegisterDTTM, "Blab user register dttm that is returned is not expected");
        }
        
        [TestMethod]
        public void Test_GetByUserIDSuccess() {
            // Arrange
            InMemory<User> _getbyuseridharness =
                new InMemory<User>(
                    new ApplicationContext(
                        new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "Get_By_User_ID")
                        .Options));

            User Expected = new User();
            User Unexpected = new User();
            Expected.Email = "name@email.com";
            Unexpected.Email = "incorrect@email.com";
            _getbyuseridharness.Add(Expected);
            _getbyuseridharness.Add(Unexpected);

            // Act
            IEnumerator<KeyValuePair<string,User>> Actual = _getbyuseridharness.GetByUserID(Expected.Email).GetEnumerator();

            // Assert
            Actual.MoveNext();
            Assert.AreEqual(Expected.Email, Actual.Current.Value.Email, "Blab user email that is returned is not expected");
            Assert.AreEqual(Expected.RegisterDTTM, Actual.Current.Value.RegisterDTTM, "Blab user register dttm that is returned is not expected");
        }
    }
}
