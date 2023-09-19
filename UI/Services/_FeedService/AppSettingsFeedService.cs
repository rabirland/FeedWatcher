using Feeder;
using Feeder.FeedSources;
using Feeder.Rss;

namespace UI.Services._FeedService;

/// <summary>
/// A type of <see cref="IFeedService"/> that uses the <see cref="ISettingsService{T}"/> with <see cref="AppSettings"/>
/// to store and read the states.
/// </summary>
public class AppSettingsFeedService : IFeedService, IDisposable
{
    private readonly IDisposable configChangedSubscription;
    private readonly ISettingsService<AppSettings> settingsService;
    private readonly Dictionary<AppSettings.Feed, IFeedReader> feedReaders = new();
    private readonly HttpClient httpClient;
    private List<Channel> channels = new List<Channel>();
    private HashSet<string> readGuids = new HashSet<string>();

    private bool channelsLoaded = false;

    public AppSettingsFeedService(ISettingsService<AppSettings> settingsService, HttpClient httpClient)
    {
        this.settingsService = settingsService;
        this.httpClient = httpClient;
        configChangedSubscription = this.settingsService.OnConfigChanged.Subscribe(ConfigurationChanged);

        ConfigurationChanged(this.settingsService.Get());
    }

    public void Dispose()
    {
        configChangedSubscription.Dispose();
    }

    /// <inheritdoc />
    public IEnumerable<Channel> GetChannels()
    {
        return channels;
    }

    /// <inheritdoc />
    public bool IsRead(string guid)
    {
        return readGuids.Contains(guid);
    }

    /// <inheritdoc />
    public void MarkRead(string guid)
    {
        var settings = settingsService.Get();

        // Clean up GUIDs that are not in the feeds anymore.
        if (channelsLoaded)
        {
            var loadedGuids = channels.SelectMany(c => c.Items).Select(item => item.Guid).ToArray();
            settings.ReadArticles.RemoveAll(guid => loadedGuids.Contains(guid) == false);
        }

        settings.ReadArticles.Add(guid);
        settingsService.Update(settings);
    }

    private void ConfigurationChanged(AppSettings config)
    {
        var newReaders = config.Feeds.Where(f => feedReaders.ContainsKey(f) == false).ToArray();
        var removedReaders = feedReaders.Keys.Where(f => config.Feeds.Contains(f) == false).ToArray();

        foreach (var entry in removedReaders)
        {
            feedReaders.Remove(entry);
        }

        foreach (var entry in newReaders)
        {
            var reader = ConstructReader(entry);
            feedReaders.Add(entry, reader);
        }
    }

    private IFeedReader ConstructReader(AppSettings.Feed feedSetting)
    {
        return feedSetting.Provider switch
        {
            AppSettings.FeedProvider.Rss => new RssFeedReader(new HttpFeedSource(httpClient, feedSetting.Uri)),
            _ => throw new Exception("Unsupported feed provider"),
        };
    }
}
