using System;

namespace Steam_Server_Creation_Tool_V2
{
    /// <summary>
    /// Class to store app information
    /// </summary>
    [Serializable]
    public class InstalledServer
    {
        public string name;
        public string installPath;
        public App app;

        public InstalledServer(string name, string installPath, App app)
        {
            this.name = name;
            this.installPath = installPath;
            this.app = app;
        }
    }
}
