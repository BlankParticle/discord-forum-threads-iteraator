import "dotenv/config";
import { createInterface } from "node:readline/promises";

// Type definitions based on threads.json structure
interface AvatarDecorationData {
  asset: string;
  sku_id: string;
  expires_at: string | null;
}

interface CollectiblesNameplate {
  sku_id: string;
  asset: string;
  label: string;
  palette: string;
}

interface Collectibles {
  nameplate: CollectiblesNameplate;
}

interface Clan {
  identity_guild_id: string;
  identity_enabled: boolean;
  tag: string;
  badge: string;
}

interface PrimaryGuild {
  identity_guild_id: string;
  identity_enabled: boolean;
  tag: string;
  badge: string;
}

interface Author {
  id: string;
  username: string;
  avatar: string;
  discriminator: string;
  public_flags: number;
  flags: number;
  banner: string | null;
  accent_color: string | null;
  global_name: string;
  avatar_decoration_data: AvatarDecorationData;
  collectibles: Collectibles;
  banner_color: string | null;
  clan: Clan;
  primary_guild: PrimaryGuild;
}

interface Attachment {
  id: string;
  filename: string;
  size: number;
  url: string;
  proxy_url: string;
  width: number;
  height: number;
  content_type: string;
  content_scan_version: number;
  placeholder: string;
  placeholder_version: number;
}

interface EmbedAuthor {
  name: string;
  url: string;
  icon_url: string;
  proxy_icon_url: string;
}

interface EmbedImage {
  url: string;
  proxy_url: string;
  width: number;
  height: number;
  content_type: string;
  placeholder: string;
  placeholder_version: number;
  flags: number;
}

interface EmbedFooter {
  text: string;
  icon_url: string;
  proxy_icon_url: string;
}

interface Embed {
  type: string;
  url: string;
  description: string;
  color: number;
  timestamp: string;
  author: EmbedAuthor;
  image: EmbedImage;
  footer: EmbedFooter;
  content_scan_version: number;
}

interface Message {
  type: number;
  content: string;
  mentions: any[];
  mention_roles: any[];
  attachments: Attachment[];
  embeds: Embed[];
  timestamp: string;
  edited_timestamp: string | null;
  flags: number;
  components: any[];
  id: string;
  channel_id: string;
  author: Author;
  pinned: boolean;
  mention_everyone: boolean;
  tts: boolean;
}

interface ThreadMetadata {
  archived: boolean;
  archive_timestamp: string;
  auto_archive_duration: number;
  locked: boolean;
  create_timestamp: string;
}

interface Thread {
  id: string;
  type: number;
  last_message_id: string;
  flags: number;
  guild_id: string;
  name: string;
  parent_id: string;
  rate_limit_per_user: number;
  bitrate: number;
  user_limit: number;
  rtc_region: string | null;
  owner_id: string;
  thread_metadata: ThreadMetadata;
  message_count: number;
  member_count: number;
  total_message_sent: number;
  applied_tags: string[];
}

interface ThreadsResponse {
  threads: Thread[];
  has_more: boolean;
  first_messages: Message[];
  total_results: number;
}

const dateToSnowflake = (date: Date) =>
  ((BigInt(date.valueOf()) - BigInt(1420070400000)) << BigInt(22)).toString();

type ForumThreadsIteratorOptions = {
  channelId: string;
  afterId?: string;
  limit?: number;
  tag?: string;
  sortOrder?: "asc" | "desc";
  authToken: string;
};

export class ForumThreadsIterator {
  private storage: ThreadsResponse[] = [];
  public totalResults = 0;
  public hasMore = true;

  constructor(private options: ForumThreadsIteratorOptions) {}

  private buildSearchParams() {
    const { afterId, limit = 25, tag, sortOrder = "asc" } = this.options;
    const searchParams = new URLSearchParams();
    if (afterId) searchParams.set("min_id", afterId);
    if (limit) searchParams.set("limit", limit.toString());
    if (tag) searchParams.set("tag", tag);
    if (sortOrder) searchParams.set("sort_order", sortOrder);
    return searchParams.toString();
  }

  async fetch() {
    const res: ThreadsResponse = await fetch(
      `https://discord.com/api/v10/channels/${
        this.options.channelId
      }/threads/search?${this.buildSearchParams()}`,
      {
        headers: {
          Authorization: this.options.authToken,
        },
      }
    ).then((res) => res.json());
    this.storage.push(res);
    this.totalResults = res.total_results;
    this.hasMore = res.has_more;
    this.options.afterId = res.threads[res.threads.length - 1].id;
    return res;
  }

  async *[Symbol.asyncIterator]() {
    while (this.hasMore) {
      const res = await this.fetch();
      for (const thread of res.threads) {
        yield thread;
      }
    }
  }
}

const FORUM_CHANNEL_ID = "1386922447583973437";

const iterator = new ForumThreadsIterator({
  channelId: FORUM_CHANNEL_ID,
  authToken: `Bot ${process.env.DISCORD_TOKEN}`,
});

const rl = createInterface({
  input: process.stdin,
  output: process.stdout,
});

console.log(`Fetching threads in Channel #${FORUM_CHANNEL_ID}...\n`);

for await (const message of iterator) {
  console.log(message);
  await rl.question("Press Enter to continue...").catch(() => process.exit(0));
  console.log("--------------------------------");
}
