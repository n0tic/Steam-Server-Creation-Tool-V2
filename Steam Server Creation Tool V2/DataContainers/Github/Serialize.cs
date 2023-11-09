using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Server_Creation_Tool_V2.DataContainers.Github
{
    public static class Serialize
    {
        public static string ToJson(this List<GithubReleasesData> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
