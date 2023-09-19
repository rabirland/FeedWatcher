using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text.Json;

namespace UI.Services;

/// <summary>
/// A type of <see cref="ISettingsService{T}"/> that uses JSON file to store the settings. 
/// </summary>
/// <typeparam name="T">The type of settings.</typeparam>
public class JsonSettingsService<T> : ISettingsService<T>
{
    private readonly string configFilePath;
    private readonly Func<T> emptyConfigConstructor;
    private readonly Subject<T> configChanged = new();

    public JsonSettingsService(string configFilePath, Func<T> emptyConfigConstructor)
    {
        this.configFilePath = configFilePath;
        this.emptyConfigConstructor = emptyConfigConstructor;
    }

    /// <inheritdoc />
    public IObservable<T> OnConfigChanged => configChanged.AsObservable();

    /// <inheritdoc />
    public T Get()
    {
        if (File.Exists(configFilePath))
        {
            var json = File.ReadAllText(configFilePath);
            var config = JsonSerializer.Deserialize<T>(json);

            return config ?? emptyConfigConstructor();
        }
        else
        {
            return emptyConfigConstructor();
        }
    }

    /// <inheritdoc />
    public void Update(T config)
    {
        var json = JsonSerializer.Serialize(config);
        File.WriteAllText(configFilePath, json);

        configChanged.OnNext(config);
    }
}
