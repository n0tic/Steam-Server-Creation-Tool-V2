using Newtonsoft.Json;
using System.Collections.Generic;

namespace Steam_Server_Creation_Tool_V2.DataContainers.Github
{
    /// <summary>
    /// Serilization core
    /// </summary>
    public static class Serialize
    {
        public static string ToJson(this List<GithubReleasesData> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
