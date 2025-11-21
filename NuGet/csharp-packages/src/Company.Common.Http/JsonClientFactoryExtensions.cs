using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Common.Http;

public static class JsonClientFactoryExtensions
{
    public static IHttpClientBuilder AddJsonClient(this IServiceCollection services, string name, string baseAddress)
    {
        return services.AddHttpClient(name, client =>
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });
    }

    public static IServiceCollection AddJsonClient<TClient>(this IServiceCollection services, string baseAddress)
        where TClient : JsonClient
    {
        services.AddHttpClient<TClient>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });
        return services;
    }
}
