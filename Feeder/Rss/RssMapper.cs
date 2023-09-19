namespace Feeder.Rss;

public static class RssMapper
{
    public static Item ToStandard(this RssItem source)
    {
        return new Item(
            source.Title,
            source.Link,
            DateTime.Parse(source.PublishDate),
            source.Guid,
            source.Category,
            source.Description,
            source.Content);
    }

    public static Channel ToStandard(this RssChannel source)
    {
        return new Channel(
            source.Title,
            source.Link,
            source.Description,
            source.Copyright,
            source.Items.Select(ToStandard).ToArray());
    }
}
