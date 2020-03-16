using System;
using System.Net.Mail;
namespace BlabberApp.Domain.Entities {
    public class User : BaseEntity {
        private string _email;
        public DateTime RegisterDTTM { get; set; }
        public DateTime LastLoginDTTM { get; set; }
        public string Email {
            get { return _email; }

            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
                    throw new FormatException("Email is invalid");

                try {
                    MailAddress m = new MailAddress(value); 
                }
                catch (FormatException) {
                    throw new FormatException("Email is invalid");
                }
                _email = value;
            }
        }
    }
}