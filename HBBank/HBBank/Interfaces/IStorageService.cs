namespace HBBank.Interfaces;

/// <summary>
/// Provides methods for storing and retrieving data asynchronously.
/// </summary>
public interface IStorageService
{
    /// <summary>
    /// Stores an item in the storage with the specified key.
    /// </summary>
    /// <param name="key">The key to identify the stored item.</param>
    /// <param name="value">The value to store.</param>
    /// <typeparam name="T">The type of the value to store.</typeparam>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SetItemAsync<T>(string key, T value);

    /// <summary>
    /// Retrieves an item from the storage with the specified key.
    /// </summary>
    /// <param name="key">The key identifying the stored item.</param>
    /// <typeparam name="T">The type of the value to retrieve.</typeparam>
    /// <returns>The stored item of type <typeparamref name="T"/>.</returns>
    Task<T> GetItemAsync<T>(string key);
}