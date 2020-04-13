using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace TheCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // load the app settings into configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            // parse all settings into the Settings class structure
            var settings = configuration.Get<Settings>();

            // setup logging
            var services = new ServiceCollection() as IServiceCollection;

            services.AddLogging(configure =>
            {
                configure.AddConfiguration(configuration.GetSection("Logging"));
                configure.AddConsole();
            });

            var serviceProvider = services.BuildServiceProvider();

            // log settings that were parsed
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogDebug("Settings: {Settings}", settings);

            // dispose the serviceProvider; this will ensure all logs get flushed
            serviceProvider.Dispose();
        }
    }
}
