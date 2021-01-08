using System.Collections;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Interfaces;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Utils;

[assembly: FunctionsStartup(typeof(AzureFunctionDependencyInjection.Startup))]
namespace AzureFunctionDependencyInjection
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ICollectionUtil<Queue>, QueueUtil>();
            builder.Services.AddScoped<ICollectionUtil<Stack>, StackUtil>();
        }
    }
}