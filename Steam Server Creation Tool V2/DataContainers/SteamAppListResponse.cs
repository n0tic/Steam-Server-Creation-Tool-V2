using Newtonsoft.Json;
using System;
using System.Collections.Generic;

/// <summary>
/// Response-container for Steam API data
/// </summary>
[Serializable]
public class SteamAppListResponse
{
    [JsonProperty("applist")]
    public AppList AppList { get; set; }
}
[Serializable]
public class AppList
{
    [JsonProperty("apps")]
    public List<App> Apps { get; set; }
}
[Serializable]
public class App
{
    [JsonProperty("appid")]
    public uint AppId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    public string IdAppName { get; set; }
}
