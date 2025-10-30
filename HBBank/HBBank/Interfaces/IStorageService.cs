namespace HBBank.Interfaces;

/// <summary>
/// Provides methods for storing and retrieving data asynchronously.
/// </summary>
public interface IStorageService
{
    // Stores an item in storage with the specified key.
    Task SetItemAsync<T>(string key, T value);

    // Retrieves an item from storage with the specified key.
    Task<T> GetItemAsync<T>(string key);
}