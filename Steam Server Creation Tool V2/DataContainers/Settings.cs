using System;
using System.Collections.Generic;

namespace Steam_Server_Creation_Tool_V2
{
    /// <summary>
    /// Class to store information between sessions
    /// </summary>
    [Serializable]
    public class Settings
    {
        // User data
        public UserData userData;
        public bool useUserData = false; // Use anonymous user.

        // Steam data
        public bool autoQuit = true;

        public bool validate = true;
        public string steamCMD_installLocation = "";

        // Server data
        public List<InstalledServer> installedServer = new List<InstalledServer>();

        public string GetLogin()
        {
            if (!useUserData) return "anonymous";
            else if (useUserData && !userData.IsEmpty()) return userData.Username + " " + userData.GetPassword();
            else return null;
        }
    }
}
