using Microsoft.Extensions.Hosting;
using ServiceComponent.Configuration;
using ServiceComponent.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.Configure<ApiOptions>(context.Configuration.GetSection("Api"));
        services.AddHttpClient<IComponentClient, ComponentClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<ApiOptions>>().Value;
            client.BaseAddress = new Uri(options.BaseUrl);
        });
        services.AddScoped<IExternalUserService, ExternalUserService>();
    });

var app = builder.Build();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider.GetRequiredService<IExternalUserService>();

var user = await service.GetUserByIdAsync(2);
Console.WriteLine($"{user?.First_Name} {user?.Last_Name}");

var users = await service.GetAllUsersAsync();

    foreach (var  u in users)
    {
        Console.WriteLine($"ID: {u.Id}, Name: {u.First_Name} {u.Last_Name}, Email: {u.Email}");
    }

    Console.WriteLine($"Total Users Fetched: {users.Count()}");
