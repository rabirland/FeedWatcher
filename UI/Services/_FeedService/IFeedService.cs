using Feeder;

namespace UI.Services;

/// <summary>
/// Manages the feeds and their states.
/// </summary>
public interface IFeedService
{
    /// <summary>
    /// Fired when the channels are refreshed.
    /// </summary>
    IObservable<IEnumerable<Channel>> OnRefresh { get; }

    /// <summary>
    /// Get all the channels.
    /// </summary>
    /// <returns>The list of channels.</returns>
    IEnumerable<Channel> GetChannels();

    /// <summary>
    /// Checks if the given <paramref name="guid"/> is already read.
    /// </summary>
    /// <param name="guid">The guid of an article.</param>
    /// <returns><see langword="true"/> if the article is already read.</returns>
    bool IsRead(string guid);

    /// <summary>
    /// Marks a specified guid as read.
    /// </summary>
    /// <param name="guid"></param>
    void MarkRead(string guid);

    /// <summary>
    /// Reload all the channels from all the sources.
    /// </summary>
    /// <returns></returns>
    Task Refresh();
}
