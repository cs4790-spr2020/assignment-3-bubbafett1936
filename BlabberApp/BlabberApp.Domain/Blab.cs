namespace BlabberApp.Domain
{
    public class Blab : IDatum {
        private System.DateTime _dttm;
        private string _message;
        private string _userID;
        private string _sysID;

        public Blab() {
            _sysID = System.Guid.NewGuid().ToString();
        }

        public Blab(string uuid) {
            _sysID = uuid;
        }

        public System.DateTime DTTM {
            get { return _dttm; }
            set { _dttm = value; }
        }

        public string Message {
            get { return _message; }
            set { _message = value; }
        }

        public string UserID {
            get { return _userID; }
            set { _userID = value; }
        }

        public string getSysID() {
            return _sysID;
        }
    }
}