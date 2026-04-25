using Steam_Server_Creation_Tool_V2.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_Server_Creation_Tool_V2.Handlers.SteamAPI
{
    public class SteamServerEntry
    {
        public int AppId { get; set; }
        public string InstallPath { get; set; }

        public override string ToString()
        {
            return AppId + " - " + InstallPath;
        }
    }

    public static class SteamServerScanner
    {
        private static readonly Regex AppIdRegex =
            new Regex(@"appmanifest_(\d+)\.acf$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static List<SteamServerEntry> Scan(string rootFolder)
        {
            List<SteamServerEntry> results = new List<SteamServerEntry>();

            if (string.IsNullOrWhiteSpace(rootFolder))
                return results;

            if (!Directory.Exists(rootFolder))
                return results;

            string[] files;

            try
            {
                files = Directory.GetFiles(
                    rootFolder,
                    "appmanifest_*.acf",
                    SearchOption.AllDirectories);
            }
            catch
            {
                return results;
            }

            foreach (string file in files)
            {
                SteamServerEntry entry = Parse(file);

                if (entry != null)
                    results.Add(entry);
            }

            return results
                .GroupBy(x => x.InstallPath, StringComparer.OrdinalIgnoreCase)
                .Select(g => g.First())
                .OrderBy(x => x.AppId)
                .ToList();
        }

        private static SteamServerEntry Parse(string manifestPath)
        {
            string fileName = Path.GetFileName(manifestPath);
            Match match = AppIdRegex.Match(fileName);

            if (!match.Success)
                return null;

            int appId;
            if (!int.TryParse(match.Groups[1].Value, out appId))
                return null;

            string steamAppsFolder = Path.GetDirectoryName(manifestPath);
            if (steamAppsFolder == null)
                return null;

            DirectoryInfo parent = Directory.GetParent(steamAppsFolder);
            if (parent == null)
                return null;

            return new SteamServerEntry
            {
                AppId = appId,
                InstallPath = parent.FullName
            };
        }

        public static List<SteamServerEntry> GetCheckedSteamServerEntries(CheckedListBox listbox)
        {
            List<SteamServerEntry> result = new List<SteamServerEntry>();

            foreach (object item in listbox.CheckedItems)
            {
                SteamServerEntry entry = item as SteamServerEntry;

                if (entry != null)
                    result.Add(entry);
            }

            return result;
        }
    }
}
