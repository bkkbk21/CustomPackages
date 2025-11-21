using System.Net.Http.Json;

namespace Company.Common.Http;

public class JsonClient
{
    private readonly HttpClient _client;

    public JsonClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<T?> GetAsync<T>(string requestUri, CancellationToken cancellationToken = default)
    {
        using var response = await _client.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string requestUri, TRequest body, CancellationToken cancellationToken = default)
    {
        using var response = await _client.PostAsJsonAsync(requestUri, body, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<HttpResponseMessage> PostAsync<TRequest>(string requestUri, TRequest body, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync(requestUri, body, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        return response;
    }
}
