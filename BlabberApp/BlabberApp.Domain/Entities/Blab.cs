namespace BlabberApp.Domain.Entities
{
    public class Blab : BaseEntity {
        private string _message;
        private string _userID;

        public string Message {
            get { return _message; }
            set { _message = value; }
        }

        public string UserID {
            get { return _userID; }
            set { _userID = value; }
        }
    }
}