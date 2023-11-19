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
        // User data / Settings
        public UserData userData;
        public bool useAnonymousAuth = true; // Use anonymous user.

        // Software/Steam parameters
        public bool CheckUpdates = true;
        public bool autoClose = true;
        public bool validate = true;
        public bool allowAutoUpdate = false; // False positive as of right now. Disabled.
        public bool wrapSteamCMD = true; // False positive as of right now. Disabled.
        public bool SupressNoneError = false; // False positive as of right now. Disabled.

        // SteamCMD install directory
        public string steamCMD_installLocation = "";

        // Server data
        public List<InstalledServer> installedServer = new List<InstalledServer>();

        /// <summary>
        /// Get login information as string to use as parameters in SteamCMD client.
        /// </summary>
        /// <returns></returns>
        public string GetLogin()
        {
            if (useAnonymousAuth) return "anonymous";
            else if (!useAnonymousAuth && !userData.IsEmpty()) return userData.Username + " " + userData.GetPassword();
            else return null;
        }
    }
}
