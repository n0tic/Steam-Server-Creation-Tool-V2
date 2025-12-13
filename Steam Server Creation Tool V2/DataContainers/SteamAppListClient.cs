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
            Console.WriteLine(responseString);
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
    public SteamAppListResponse FilterAndSortAppList(SteamAppListResponse data)
    {
        var list = data?.Response?.Apps;
        if (list == null || list.Count == 0)
            return data;

        // Remove duplicates based on AppId
        data.Response.Apps = list
            .GroupBy(app => app.AppId)
            .Select(group => group.First())
            .ToList();

        list = data.Response.Apps;

        // Identifying indexes to remove
        var removeIndexes = list
            .Select((app, index) => new { app, index })
            .Where(x =>
                (x.app.AppId != 570 && x.app.AppId != 730) &&
                (x.app.Name.Equals("Dedicated Server") ||
                 !x.app.Name.Contains("Server") ||
                 x.app.Name.Contains("linux")))
            .Select(x => x.index)
            .ToList();

        foreach (var item in list)
        {
            if (item.AppId == 90) item.IdAppName = $"[{item.AppId}] Counter-strike 1.6 and {item.Name}";
            else item.IdAppName = $"[{item.AppId}] {item.Name}";
        }

        removeIndexes.Sort((a, b) => b.CompareTo(a));
        removeIndexes.ForEach(index => list.RemoveAt(index));

        GC.Collect();

        list.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));

        return data;
    }

}