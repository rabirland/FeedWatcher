namespace Feeder.FeedSources;

/// <summary>
/// A feed source that gets the content from a HTTP server.
/// </summary>
public class HttpFeedSource : IFeedSource
{
    private readonly HttpClient client;
    private readonly string uri;

    /// <summary>
    /// Initializes a new <see cref="HttpFeedSource"/>.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> to use to access the HTTP server.</param>
    /// <param name="uri">The feed's URI.</param>
    public HttpFeedSource(HttpClient client, string uri)
    {
        this.client = client;
        this.uri = uri;
    }

    /// <inheritdoc />
    public Task<string> Read()
    {
        return client.GetStringAsync(uri);
    }
}
