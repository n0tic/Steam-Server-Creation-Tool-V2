using System;

namespace Steam_Server_Creation_Tool_V2
{
    [Serializable]
    public class UserData
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public UserData()
        {
            this.Username = null;
            this.Password = null;
        }

        public bool IsEmpty()
        {
            if (string.IsNullOrWhiteSpace(this.Username) || this.Password == null || this.Password.Length < 1) return true;
            else return false;
        }

        public void SetUsername(string name) => this.Username = name;

        public void SetPassword(string pass) => this.Password = Core.Base64Encode(pass);

        public string GetPassword()
        {
            try
            {
                return Core.Base64Decode(this.Password);
            }
            catch { return null; }
        }
    }
}
