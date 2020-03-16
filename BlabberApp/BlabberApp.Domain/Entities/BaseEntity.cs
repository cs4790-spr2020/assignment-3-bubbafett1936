using System;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class BaseEntity : IBaseEntity {
        private string _sysID;
        public string SysID {
            get { return _sysID; }
            private set { _sysID = value; }
        }
        public string User {
            get {
                if (this is Blab) {
                    Blab blab = (Blab) this;
                    return blab.UserID;
                }
                
                User user = (User) this;
                return user.Email;
            }
        }
        public DateTime CreatedDTTM { get; set; }
        public DateTime ModifiedDTTM { get; set; }
        
        public BaseEntity() {
           SysID = Guid.NewGuid().ToString(); 
           CreatedDTTM = DateTime.Now;
           ModifiedDTTM = DateTime.Now; 
        }

        public string getSysID() {
            return _sysID;
        }

        public void Modify() {
           ModifiedDTTM = DateTime.Now;
        }

        public bool Equals(string AnotherID) {
            return _sysID.Equals(AnotherID);
        }
    }
}