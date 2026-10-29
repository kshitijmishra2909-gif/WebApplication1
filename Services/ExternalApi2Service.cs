using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Services;

/// <summary>Calls both configured external APIs.</summary>
public sealed class ExternalApi2Service
{
    private readonly HttpClient _externalApiClient;
    private readonly HttpClient _externalApi2Client;

    /// <summary>Creates the service with both shared external API clients.</summary>
    public ExternalApi2Service(
        [FromKeyedServices("ExternalApi")] HttpClient externalApiClient,
        [FromKeyedServices("ExternalApi2")] HttpClient externalApi2Client)
    {
        _externalApiClient = externalApiClient;
        _externalApi2Client = externalApi2Client;
    }

    /// <summary>Fetches a JSON resource from ExternalApi.</summary>
    public Task<TResponse?> GetFromExternalApiAsync<TResponse>(
        string relativeUri,
        CancellationToken cancellationToken)
    {
        return _externalApiClient.GetFromJsonAsync<TResponse>(relativeUri, cancellationToken);
    }

    /// <summary>Fetches a JSON resource from ExternalApi2.</summary>
    public Task<TResponse?> GetFromExternalApi2Async<TResponse>(
        string relativeUri,
        CancellationToken cancellationToken)
    {
        return _externalApi2Client.GetFromJsonAsync<TResponse>(relativeUri, cancellationToken);
    }
}