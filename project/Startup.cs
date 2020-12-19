using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using FS.Interfaces;
using FS.Utils;

[assembly: FunctionsStartup(typeof(AzureFunctionDependencyInjection.Startup))]
namespace AzureFunctionDependencyInjection
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ICollectionHandler<Queue>, QueueHandler<Queue>>();
            builder.Services.AddScoped<ICollectionHandler<Stack>, StackHandler<Stack>>();
        }
    }
}