using Newtonsoft.Json;
using System;
using System.Collections.Generic;

[Serializable]
public class SteamAppListResponse
{
    [JsonProperty("response")]
    public ResponseData Response { get; set; }
}

[Serializable]
public class ResponseData
{
    [JsonProperty("apps")]
    public List<App> Apps { get; set; }

    [JsonProperty("have_more_results")]
    public bool HaveMoreResults { get; set; }

    [JsonProperty("last_appid")]
    public uint LastAppId { get; set; }
}

[Serializable]
public class App
{
    [JsonProperty("appid")]
    public uint AppId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    // Extra fält i nya JSON:en (valfritt, men bra att ha)
    [JsonProperty("last_modified")]
    public long? LastModified { get; set; }

    [JsonProperty("price_change_number")]
    public long? PriceChangeNumber { get; set; }

    public string IdAppName { get; set; }
}
