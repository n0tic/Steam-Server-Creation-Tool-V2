using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

public class SteamAppListClient
{
    private readonly HttpClient _httpClient;

    public SteamAppListClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SteamAppListResponse> GetAppListAsync()
    {
        try
        {
            const string requestUri = "https://api.steampowered.com/ISteamApps/GetAppList/v2/";
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

    public SteamAppListResponse FilterAndSortAppList(SteamAppListResponse apps)
    {
        // Identifying indexes to remove
        var removeIndexes = apps.AppList.Apps
            .Select((app, index) => new { app, index })
            .Where(x => (x.app.AppId != 570 && x.app.AppId != 730) && (x.app.Name.Equals("Dedicated Server") || !x.app.Name.Contains("Server") || x.app.Name.Contains("linux")))
            .Select(x => x.index)
            .ToList(); // 730

        foreach (var item in apps.AppList.Apps)
        {
            item.IdAppName = $"[{item.AppId}] {item.Name}";
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