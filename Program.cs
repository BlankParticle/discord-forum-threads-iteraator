using DiscordBotPlay;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DiscordBotPlay;

class Program
{
    static async Task Main(string[] args)
    {
        const string FORUM_CHANNEL_ID = "1386922447583973437";
      
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        var discordToken = configuration["DISCORD_TOKEN"];
        if (string.IsNullOrEmpty(discordToken))
        {
            Console.WriteLine("Error: DISCORD_TOKEN environment variable is not set.");
            Console.WriteLine("Please set your Discord bot token as an environment variable.");
            return;
        }


        var iterator = new ForumThreadsIterator(new ForumThreadsIteratorOptions
        {
            ChannelId = FORUM_CHANNEL_ID,
            AuthToken = $"Bot {discordToken}",
            Limit = 20
        });

        Console.WriteLine($"Fetching threads in Channel #{FORUM_CHANNEL_ID}...\n");

        try
        {
            await foreach (var thread in iterator)
            {
                Console.WriteLine(JsonConvert.SerializeObject(thread, Formatting.Indented));
                Console.WriteLine("Press Enter to continue... (or Ctrl+C to exit)");
                
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape || key.Modifiers == ConsoleModifiers.Control)
                {
                    break;
                }
                
                Console.WriteLine("--------------------------------");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
} 