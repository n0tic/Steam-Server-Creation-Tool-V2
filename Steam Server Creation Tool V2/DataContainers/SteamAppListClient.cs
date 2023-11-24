using Newtonsoft.Json;
using Steam_Server_Creation_Tool_V2;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Class to control data gathering from Steam API regarding their database with games, servers and applications
/// </summary>
[Serializable]
public class SteamAppListClient
{
    private readonly HttpClient _httpClient;

    public SteamAppListClient(HttpClient httpClient) => _httpClient = httpClient;

    /// <summary>
    /// Get results from Steam API, filter the data and return the results
    /// </summary>
    /// <returns></returns>
    public async Task<SteamAppListResponse> GetAppListAsync()
    {
        try
        {
            string requestUri = Core.serversURL + Core.GetUTCTime();
            var responseString = await _httpClient.GetStringAsync(requestUri);
            var appListResponse = JsonConvert.DeserializeObject<SteamAppListResponse>(responseString);

            appListResponse = FilterAndSortAppList(appListResponse);

            GC.Collect();

            return appListResponse;
        }
        catch (HttpRequestException e)
        {
            MessageBox.Show(e.Message, "Error reading data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error reading data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
    }

    /// <summary>
    /// Filters and order the data from Steam API
    /// </summary>
    /// <param name="apps"></param>
    /// <returns></returns>
    public SteamAppListResponse FilterAndSortAppList(SteamAppListResponse apps)
    {
        // Identifying indexes to remove
        var removeIndexes = apps.AppList.Apps
            .Select((app, index) => new { app, index })
            .Where(x => (x.app.AppId != 570 && x.app.AppId != 730) && (x.app.Name.Equals("Dedicated Server") || !x.app.Name.Contains("Server") || x.app.Name.Contains("linux")))
            .Select(x => x.index)
            .ToList();

        foreach (var item in apps.AppList.Apps)
        {
            if(item.AppId == 90) item.IdAppName = $"[{item.AppId}] Counter-strike 1.6 and {item.Name}";
            else item.IdAppName = $"[{item.AppId}] {item.Name}";

        }

        // Sort in descending order to avoid index shifting issues during removal
        removeIndexes.Sort((a, b) => b.CompareTo(a));

        // Remove items from the list
        removeIndexes.ForEach(index => apps.AppList.Apps.RemoveAt(index));

        // Optional: Force garbage collection
        GC.Collect();

        // Sort the apps by name
        apps.AppList.Apps.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));

        return apps;
    }
}