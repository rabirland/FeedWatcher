namespace Feeder;

public record Channel(
    string Title,
    string Link,
    string Description,
    string Copyright,
    IEnumerable<Item> Items);

public record Item(
    string Title,
    string Link,
    DateTime PublishDate,
    string Guid,
    string Category,
    string Description,
    string Content);
