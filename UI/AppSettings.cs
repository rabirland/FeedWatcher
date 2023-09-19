namespace UI;

public class AppSettings
{
    /// <summary>
    /// The list of configured feeds.
    /// </summary>
    public List<Feed> Feeds { get; set; } = new();

    /// <summary>
    /// The list of article GUIDs that are already read.
    /// </summary>
    public List<string> ReadArticles { get; set; } = new();

    public readonly record struct Feed(FeedProvider Provider, string Uri);

    public enum FeedProvider
    {
        Rss,
    }
}
