# Forum Threads Iterator - .NET Version

## Prerequisites

- .NET 9.0 SDK or later
- A Discord bot token

## Setup

1. **Install .NET 9.0 SDK** if you haven't already:

   - Download from: https://dotnet.microsoft.com/download/dotnet/9.0

2. **Set your Discord bot token** as an environment variable:

   ```bash
   # On macOS/Linux
   export DISCORD_TOKEN="your_discord_bot_token_here"

   # On Windows (Command Prompt)
   set DISCORD_TOKEN=your_discord_bot_token_here

   # On Windows (PowerShell)
   $env:DISCORD_TOKEN="your_discord_bot_token_here"
   ```

   Alternatively, you can create a `.env` file in the project root:

   ```
   DISCORD_TOKEN=your_discord_bot_token_here
   ```

## Running the Application

1. **Restore dependencies**:

   ```bash
   dotnet restore
   ```

2. **Build the project**:

   ```bash
   dotnet build
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

## Features

- **Forum Thread Iterator**: Fetches Discord forum threads with pagination support
- **Async Enumeration**: Uses C#'s `IAsyncEnumerable<T>` for efficient streaming of results
- **Configuration Management**: Supports environment variables and JSON configuration
- **Error Handling**: Comprehensive error handling for HTTP requests and JSON deserialization
- **Interactive Console**: Press Enter to continue viewing threads, or Ctrl+C to exit

## Project Structure

- `Program.cs` - Main entry point and application logic
- `ForumThreadsIterator.cs` - Core iterator class for fetching Discord threads
- `Models/ThreadModels.cs` - C# model classes for Discord API responses
- `DiscordBotPlay.csproj` - Project file with dependencies
- `appsettings.json` - Configuration file

## Dependencies

- **Newtonsoft.Json** - JSON serialization/deserialization
- **Microsoft.Extensions.Configuration** - Configuration management
- **Microsoft.Extensions.Configuration.EnvironmentVariables** - Environment variable support
- **Microsoft.Extensions.Configuration.Json** - JSON configuration support

## API Endpoint

The application uses Discord's API v10 endpoint:

```
GET https://discord.com/api/v10/channels/{channelId}/threads/search
```

## Configuration Options

The `ForumThreadsIteratorOptions` class supports:

- `ChannelId` - Discord channel ID to fetch threads from
- `AfterId` - Optional thread ID to start fetching after (for pagination)
- `Limit` - Number of threads to fetch per request (default: 25)
- `Tag` - Optional tag filter
- `SortOrder` - Sort order ("asc" or "desc")
- `AuthToken` - Discord bot authorization token

## Error Handling

The application handles various error scenarios:

- Missing Discord token
- HTTP request failures
- JSON deserialization errors
- Network connectivity issues
