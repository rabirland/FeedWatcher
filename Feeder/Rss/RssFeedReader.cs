using System.Text;
using System.Xml.Serialization;

namespace Feeder.Rss;

/// <summary>
/// A <see cref="IFeedReader"/> that reads RSS feeds.
/// </summary>
public class RssFeedReader : IFeedReader
{
    private readonly IFeedSource source;

    /// <summary>
    /// Initializes a new <see cref="RssFeedReader"/>.
    /// </summary>
    /// <param name="source">The source to read the RSS feed from.</param>
    public RssFeedReader(IFeedSource source)
    {
        this.source = source;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Channel>> Read()
    {
        var content = await source.Read();

        XmlSerializer serializer = new XmlSerializer(typeof(RssFeed));


        var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

        var deserialized = serializer.Deserialize(stream);
        var feed = (RssFeed)(deserialized ?? throw new Exception("Could not read RSS feed"));

        return feed
            .Channels
            .Select(RssMapper.ToStandard)
            .ToArray();
    }
}
