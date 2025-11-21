using Company.Common.Http;
using Company.Common.Utils;
using Microsoft.Extensions.DependencyInjection;

// Build DI container with JsonClient
var services = new ServiceCollection();
services.AddJsonClient<JsonClient>("https://postman-echo.com");
var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<JsonClient>();

// Use utils
Console.WriteLine("Capitalize: " + "hello world".Capitalize());
Console.WriteLine("Iso: " + DateTime.UtcNow.ToIsoDate());
Console.WriteLine("Clamp: " + MathHelpers.Clamp(12, 0, 10));

// Call sample echo API
var echo = await client.GetAsync<object>("/get?ping=pong");
Console.WriteLine("HTTP result: " + (echo?.ToString() ?? "<null>"));
