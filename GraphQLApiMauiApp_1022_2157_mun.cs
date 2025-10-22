// 代码生成时间: 2025-10-22 21:57:37
using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace GraphQLMauiApp
{
    // GraphQL Startup class
    public class GraphQLStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add GraphQL services
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddTypeExtension<ErrorType>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Set up GraphQL endpoint
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }

    // Query resolvers
    public class Query
    {
        public string GetGreeting(string name)
        {
            return $"Hello, {name}!";
        }
    }

    // Error type extension for GraphQL
    public class ErrorTypeExtension
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    // GraphQL exception filter
    public class GraphQLExceptionFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            // Log error details (Implementation not shown for brevity)
            // ...

            // Return a user-friendly error
            return new ErrorBuilder(error)
                .SetMessage("An unexpected error occurred.")
                .Build();
        }
    }

    // Main class to run the MAUI application
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register GraphQL services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<GraphQLStartup>();

            // Configure the HTTP request pipeline
            var app = builder.Build();

            // Use GraphQLStartup to configure GraphQL services
            var graphQLStartup = app.Services.GetRequiredService<GraphQLStartup>();
            graphQLStartup.ConfigureServices(app.Services);
            graphQLStartup.Configure(app, app.Environment);

            // Run the application
            await app.RunAsync();
        }
    }
}
