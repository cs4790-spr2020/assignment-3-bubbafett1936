using System;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class BaseEntity : IBaseEntity {
        private string _sysID;
        public DateTime CreatedDTTM { get; set; }
        public DateTime ModifiedDTTM { get; set; }
        
        public BaseEntity() {
           _sysID = Guid.NewGuid().ToString(); 
           CreatedDTTM = DateTime.Now;
           ModifiedDTTM = DateTime.Now; 
        }

        public string getSysID() {
            return _sysID;
        }

        public bool Equals(string AnotherID) {
            return _sysID.Equals(AnotherID);
        }
    }
}