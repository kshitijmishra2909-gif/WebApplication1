using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1;

/// <summary>Application entry point and dependency-injection setup.</summary>
public class Program
{
    /// <summary>Starts the web application.</summary>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            var xmlFile = $"{typeof(Program).Assembly.GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
        });
        builder.Services.AddHttpClient("ExternalApi", client =>
        {
            var baseAddress = builder.Configuration["ExternalApi:BaseAddress"];
            if (!string.IsNullOrWhiteSpace(baseAddress))
            {
                client.BaseAddress = new Uri(baseAddress, UriKind.Absolute);
            }

            client.Timeout = TimeSpan.FromSeconds(
                builder.Configuration.GetValue("ExternalApi:TimeoutSeconds", 30));
        })
        .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(2)
        })
        .SetHandlerLifetime(Timeout.InfiniteTimeSpan);
        builder.Services.AddHttpClient("ExternalApi2", client =>
        {
            var baseAddress = builder.Configuration["ExternalApi2:BaseAddress"];
            if (!string.IsNullOrWhiteSpace(baseAddress))
            {
                client.BaseAddress = new Uri(baseAddress, UriKind.Absolute);
            }

            client.Timeout = TimeSpan.FromSeconds(
                builder.Configuration.GetValue("ExternalApi2:TimeoutSeconds", 30));
        })
        .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(2)
        })
        .SetHandlerLifetime(Timeout.InfiniteTimeSpan);
        builder.Services.AddKeyedSingleton("ExternalApi", (serviceProvider, _) =>
            serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient("ExternalApi"));
        builder.Services.AddKeyedSingleton("ExternalApi2", (serviceProvider, _) =>
            serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient("ExternalApi2"));
        builder.Services.AddSingleton<IWorkItemRepository, InMemoryWorkItemRepository>();
        builder.Services.AddSingleton<ExternalApiService>();
        builder.Services.AddSingleton<ExternalApi2Service>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
