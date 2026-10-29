using System.Net.Http.Json;

namespace WebApplication1.Services;

/// <summary>Calls the configured external API.</summary>
public sealed class ExternalApiService
{
    private readonly HttpClient _httpClient;

    /// <summary>Creates the service with the shared ExternalApi client.</summary>
    public ExternalApiService([FromKeyedServices("ExternalApi")] HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>Fetches a JSON resource from the external API.</summary>
    public Task<TResponse?> GetJsonAsync<TResponse>(
        string relativeUri,
        CancellationToken cancellationToken)
    {
        return _httpClient.GetFromJsonAsync<TResponse>(relativeUri, cancellationToken);
    }

}