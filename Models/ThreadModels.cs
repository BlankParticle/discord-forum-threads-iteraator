using Newtonsoft.Json;

namespace DiscordBotPlay.Models;

public class AvatarDecorationData
{
    [JsonProperty("asset")]
    public string Asset { get; set; } = string.Empty;

    [JsonProperty("sku_id")]
    public string SkuId { get; set; } = string.Empty;

    [JsonProperty("expires_at")]
    public string? ExpiresAt { get; set; }
}

public class CollectiblesNameplate
{
    [JsonProperty("sku_id")]
    public string SkuId { get; set; } = string.Empty;

    [JsonProperty("asset")]
    public string Asset { get; set; } = string.Empty;

    [JsonProperty("label")]
    public string Label { get; set; } = string.Empty;

    [JsonProperty("palette")]
    public string Palette { get; set; } = string.Empty;
}

public class Collectibles
{
    [JsonProperty("nameplate")]
    public CollectiblesNameplate Nameplate { get; set; } = new();
}

public class Clan
{
    [JsonProperty("identity_guild_id")]
    public string IdentityGuildId { get; set; } = string.Empty;

    [JsonProperty("identity_enabled")]
    public bool IdentityEnabled { get; set; }

    [JsonProperty("tag")]
    public string Tag { get; set; } = string.Empty;

    [JsonProperty("badge")]
    public string Badge { get; set; } = string.Empty;
}

public class PrimaryGuild
{
    [JsonProperty("identity_guild_id")]
    public string IdentityGuildId { get; set; } = string.Empty;

    [JsonProperty("identity_enabled")]
    public bool IdentityEnabled { get; set; }

    [JsonProperty("tag")]
    public string Tag { get; set; } = string.Empty;

    [JsonProperty("badge")]
    public string Badge { get; set; } = string.Empty;
}

public class Author
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("username")]
    public string Username { get; set; } = string.Empty;

    [JsonProperty("avatar")]
    public string Avatar { get; set; } = string.Empty;

    [JsonProperty("discriminator")]
    public string Discriminator { get; set; } = string.Empty;

    [JsonProperty("public_flags")]
    public int PublicFlags { get; set; }

    [JsonProperty("flags")]
    public int Flags { get; set; }

    [JsonProperty("banner")]
    public string? Banner { get; set; }

    [JsonProperty("accent_color")]
    public string? AccentColor { get; set; }

    [JsonProperty("global_name")]
    public string GlobalName { get; set; } = string.Empty;

    [JsonProperty("avatar_decoration_data")]
    public AvatarDecorationData AvatarDecorationData { get; set; } = new();

    [JsonProperty("collectibles")]
    public Collectibles Collectibles { get; set; } = new();

    [JsonProperty("banner_color")]
    public string? BannerColor { get; set; }

    [JsonProperty("clan")]
    public Clan Clan { get; set; } = new();

    [JsonProperty("primary_guild")]
    public PrimaryGuild PrimaryGuild { get; set; } = new();
}

public class Attachment
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("filename")]
    public string Filename { get; set; } = string.Empty;

    [JsonProperty("size")]
    public int Size { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty("proxy_url")]
    public string ProxyUrl { get; set; } = string.Empty;

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("content_type")]
    public string ContentType { get; set; } = string.Empty;

    [JsonProperty("content_scan_version")]
    public int ContentScanVersion { get; set; }

    [JsonProperty("placeholder")]
    public string Placeholder { get; set; } = string.Empty;

    [JsonProperty("placeholder_version")]
    public int PlaceholderVersion { get; set; }
}

public class EmbedAuthor
{
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty("icon_url")]
    public string IconUrl { get; set; } = string.Empty;

    [JsonProperty("proxy_icon_url")]
    public string ProxyIconUrl { get; set; } = string.Empty;
}

public class EmbedImage
{
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty("proxy_url")]
    public string ProxyUrl { get; set; } = string.Empty;

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("content_type")]
    public string ContentType { get; set; } = string.Empty;

    [JsonProperty("placeholder")]
    public string Placeholder { get; set; } = string.Empty;

    [JsonProperty("placeholder_version")]
    public int PlaceholderVersion { get; set; }

    [JsonProperty("flags")]
    public int Flags { get; set; }
}

public class EmbedFooter
{
    [JsonProperty("text")]
    public string Text { get; set; } = string.Empty;

    [JsonProperty("icon_url")]
    public string IconUrl { get; set; } = string.Empty;

    [JsonProperty("proxy_icon_url")]
    public string ProxyIconUrl { get; set; } = string.Empty;
}

public class Embed
{
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;

    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    [JsonProperty("color")]
    public int Color { get; set; }

    [JsonProperty("timestamp")]
    public string Timestamp { get; set; } = string.Empty;

    [JsonProperty("author")]
    public EmbedAuthor Author { get; set; } = new();

    [JsonProperty("image")]
    public EmbedImage Image { get; set; } = new();

    [JsonProperty("footer")]
    public EmbedFooter Footer { get; set; } = new();

    [JsonProperty("content_scan_version")]
    public int ContentScanVersion { get; set; }
}

public class Message
{
    [JsonProperty("type")]
    public int Type { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; } = string.Empty;

    [JsonProperty("mentions")]
    public object[] Mentions { get; set; } = Array.Empty<object>();

    [JsonProperty("mention_roles")]
    public object[] MentionRoles { get; set; } = Array.Empty<object>();

    [JsonProperty("attachments")]
    public Attachment[] Attachments { get; set; } = Array.Empty<Attachment>();

    [JsonProperty("embeds")]
    public Embed[] Embeds { get; set; } = Array.Empty<Embed>();

    [JsonProperty("timestamp")]
    public string Timestamp { get; set; } = string.Empty;

    [JsonProperty("edited_timestamp")]
    public string? EditedTimestamp { get; set; }

    [JsonProperty("flags")]
    public int Flags { get; set; }

    [JsonProperty("components")]
    public object[] Components { get; set; } = Array.Empty<object>();

    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("channel_id")]
    public string ChannelId { get; set; } = string.Empty;

    [JsonProperty("author")]
    public Author Author { get; set; } = new();

    [JsonProperty("pinned")]
    public bool Pinned { get; set; }

    [JsonProperty("mention_everyone")]
    public bool MentionEveryone { get; set; }

    [JsonProperty("tts")]
    public bool Tts { get; set; }
}

public class ThreadMetadata
{
    [JsonProperty("archived")]
    public bool Archived { get; set; }

    [JsonProperty("archive_timestamp")]
    public string ArchiveTimestamp { get; set; } = string.Empty;

    [JsonProperty("auto_archive_duration")]
    public int AutoArchiveDuration { get; set; }

    [JsonProperty("locked")]
    public bool Locked { get; set; }

    [JsonProperty("create_timestamp")]
    public string CreateTimestamp { get; set; } = string.Empty;
}

public class ForumThread
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("type")]
    public int Type { get; set; }

    [JsonProperty("last_message_id")]
    public string LastMessageId { get; set; } = string.Empty;

    [JsonProperty("flags")]
    public int Flags { get; set; }

    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("parent_id")]
    public string ParentId { get; set; } = string.Empty;

    [JsonProperty("rate_limit_per_user")]
    public int RateLimitPerUser { get; set; }

    [JsonProperty("bitrate")]
    public int Bitrate { get; set; }

    [JsonProperty("user_limit")]
    public int UserLimit { get; set; }

    [JsonProperty("rtc_region")]
    public string? RtcRegion { get; set; }

    [JsonProperty("owner_id")]
    public string OwnerId { get; set; } = string.Empty;

    [JsonProperty("thread_metadata")]
    public ThreadMetadata ThreadMetadata { get; set; } = new();

    [JsonProperty("message_count")]
    public int MessageCount { get; set; }

    [JsonProperty("member_count")]
    public int MemberCount { get; set; }

    [JsonProperty("total_message_sent")]
    public int TotalMessageSent { get; set; }

    [JsonProperty("applied_tags")]
    public string[] AppliedTags { get; set; } = Array.Empty<string>();
}

public class ThreadsResponse
{
    [JsonProperty("threads")]
    public ForumThread[] Threads { get; set; } = Array.Empty<ForumThread>();

    [JsonProperty("has_more")]
    public bool HasMore { get; set; }

    [JsonProperty("first_messages")]
    public Message[] FirstMessages { get; set; } = Array.Empty<Message>();

    [JsonProperty("total_results")]
    public int TotalResults { get; set; }
} 