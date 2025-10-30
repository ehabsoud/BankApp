using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace HBBank.Services;

/// <summary>
/// Service for interacting with browser localStorage using JSInterop.
/// Provides generic methods to save and retrieve objects as JSON.
/// </summary>
public class StorageService : IStorageService
{
    // Reference to JS runtime to invoke JavaScript functions.
    private readonly IJSRuntime _jsRuntime;

    // JSON serialization options: use camelCase and handle enums as strings.
    private JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() }
    };

    /// <summary>
    /// Initializes a new instance of <see cref="StorageService"/>.
    /// </summary>
    /// <param name="jsRuntime">The JS runtime used for JavaScript interop calls.</param>
    public StorageService(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;

    /// <summary>
    /// Saves an object to localStorage under the specified key.
    /// </summary>
    /// <param name="key">The key under which to store the value.</param>
    /// <param name="value">The object to store.</param>
    /// <typeparam name="T">The type of object to store.</typeparam>
    public async Task SetItemAsync<T>(string key, T value)
    {
        // Serialize the object to JSON.
        var json = JsonSerializer.Serialize(value, _jsonSerializerOptions);

        // Store the JSON string in localStorage via JSInterop.
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, json);
    }

    /// <summary>
    /// Retrieves an object from localStorage by key.
    /// </summary>
    /// <param name="key">The key of the stored item.</param>
    /// <typeparam name="T">The type of the object to retrieve.</typeparam>
    /// <returns>The deserialized object from localStorage, or default(T) if the key does not exist.</returns>
    public async Task<T> GetItemAsync<T>(string key)
    {
        // Retrieve JSON string from localStorage.
        var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

        // Return default if nothing found.
        if (string.IsNullOrEmpty(json))
            return default;

        // Deserialize JSON back to the object type.
        return JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions)!;
    }
}