using Newtonsoft.Json;
using System.Collections.Generic;

public class SteamAppListResponse
{
    [JsonProperty("applist")]
    public AppList AppList { get; set; }
}

public class AppList
{
    [JsonProperty("apps")]
    public List<App> Apps { get; set; }
}

public class App
{
    [JsonProperty("appid")]
    public uint AppId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    public string IdAppName { get; set; }
}
