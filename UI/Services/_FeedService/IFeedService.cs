using Feeder;

namespace UI.Services._FeedService;

/// <summary>
/// Manages the feeds and their states.
/// </summary>
public interface IFeedService
{
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
}
