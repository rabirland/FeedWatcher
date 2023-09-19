namespace Feeder;

/// <summary>
/// A feed data source.
/// </summary>
public interface IFeedSource
{
    /// <summary>
    /// Read the current content of the feed source.
    /// </summary>
    /// <returns>An awaitable task resulting in the feed source's up to date content.</returns>
    Task<string> Read();
}
