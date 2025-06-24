using DiscordBotPlay.Models;
using Newtonsoft.Json;

namespace DiscordBotPlay;

public class ForumThreadsIteratorOptions
{
    public string ChannelId { get; set; } = string.Empty;
    public string? AfterId { get; set; }
    public int Limit { get; set; } = 25;
    public string? Tag { get; set; }
    public string SortOrder { get; set; } = "asc";
    public string AuthToken { get; set; } = string.Empty;
}

public class ForumThreadsIterator : IAsyncEnumerable<ForumThread>
{
    private readonly List<ThreadsResponse> _storage = new();
    public int TotalResults { get; private set; }
    public bool HasMore { get; private set; } = true;
    private readonly ForumThreadsIteratorOptions _options;

    public ForumThreadsIterator(ForumThreadsIteratorOptions options)
    {
        _options = options;
    }

    private string BuildSearchParams()
    {
        var queryParams = new List<string>();
        
        if (!string.IsNullOrEmpty(_options.AfterId))
            queryParams.Add($"min_id={_options.AfterId}");
        
        queryParams.Add($"limit={_options.Limit}");
        
        if (!string.IsNullOrEmpty(_options.Tag))
            queryParams.Add($"tag={_options.Tag}");
        
        queryParams.Add($"sort_order={_options.SortOrder}");
        
        return string.Join("&", queryParams);
    }

    public async Task<ThreadsResponse> FetchAsync()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", _options.AuthToken);

        var url = $"https://discord.com/api/v10/channels/{_options.ChannelId}/threads/search?{BuildSearchParams()}";
        var response = await client.GetAsync(url);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"HTTP {response.StatusCode}: {response.ReasonPhrase}");
        }

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ThreadsResponse>(json) 
            ?? throw new InvalidOperationException("Failed to deserialize response");

        _storage.Add(result);
        TotalResults = result.TotalResults;
        HasMore = result.HasMore;
        
        if (result.Threads.Length > 0)
        {
            _options.AfterId = result.Threads[result.Threads.Length - 1].Id;
        }

        return result;
    }

    public async IAsyncEnumerator<ForumThread> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        while (HasMore && !cancellationToken.IsCancellationRequested)
        {
            var response = await FetchAsync();

            // Can also use response.FirstMessages to get the first message of each thread
            foreach (var thread in response.Threads)
            {
                yield return thread;
            }
        }
    }
} 