namespace UI.Services;

/// <summary>
/// Manages the current application configuration.
/// </summary>
public interface ISettingsService<T>
{
    /// <summary>
    /// Emits a value whenever the configuration is updated.
    /// </summary>
    public IObservable<T> OnConfigChanged { get; }

    /// <summary>
    /// Get the current configuration.
    /// </summary>
    /// <returns>The current configuration.</returns>
    public T Get();

    /// <summary>
    /// Updates the entire configuration.
    /// </summary>
    public void Update(T config);
}
