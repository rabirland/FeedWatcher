namespace Feeder;

/// <summary>
/// Reads the feed into the standardized data format.
/// </summary>
public interface IFeedReader
{
    /// <summary>
    /// Read the current content of the feed.
    /// </summary>
    /// <returns>The content of the feed.</returns>
    Task<IEnumerable<Channel>> Read();
}
