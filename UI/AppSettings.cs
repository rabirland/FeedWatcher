using static UI.AppSettings;

namespace UI;

public record AppSettings(IEnumerable<Feed> Feeds, IEnumerable<string> ReadArticles)
{
    public AppSettings() : this(Enumerable.Empty<Feed>(), Enumerable.Empty<string>())
    {
    }

    public readonly record struct Feed(FeedProvider Provider, string Uri);

    public enum FeedProvider
    {
        Rss,
    }
}
