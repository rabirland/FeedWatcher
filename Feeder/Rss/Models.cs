using System.Xml.Serialization;

namespace Feeder.Rss;

[XmlRoot(ElementName = "rss")]
public record RssFeed(
    [property: XmlElement("channel")]
    RssChannel[] Channels)
{
    /// <summary>
    /// Only used for serialization
    /// </summary>
    [Obsolete]
    private RssFeed() : this(Array.Empty<RssChannel>()) { }
}

public record RssChannel(
    [property: XmlElement("title")]
    string Title,
    [property: XmlElement("link")]
    string Link,
    [property: XmlElement("description")]
    string Description,
    [property: XmlElement("copyright")]
    string Copyright,
    [property: XmlElement("item")]
    RssItem[] Items)
{
    /// <summary>
    /// Only used for serialization
    /// </summary>
    [Obsolete]
    public RssChannel() : this(string.Empty, string.Empty, string.Empty, string.Empty, Array.Empty<RssItem>()) { }
}

public record RssItem(
    [property: XmlElement("title")]
    string Title,
    [property: XmlElement("link")]
    string Link,
    [property: XmlElement("pubDate")]
    string PublishDate,
    [property: XmlElement("guid")]
    string Guid,
    [property: XmlElement("category")]
    string Category,
    [property: XmlElement("description")]
    string Description,
    [property: XmlElement("content")]
    string Content)
{
    /// <summary>
    /// Only used for serialization
    /// </summary>
    [Obsolete]
    public RssItem() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty) { }
}
