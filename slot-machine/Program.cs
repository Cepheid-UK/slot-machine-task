using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using SlotMachine.Ports;
using SlotMachine.StateMachine;
using SlotMachine.Calculations;
using SlotMachine.Slots;

namespace SlotMachine
{
    public class Program
    {
        public static IConfigurationRoot configuration;
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<IGame>()
                .StartGame();
        }
        
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISlotsGenerator, SlotsGenerator>()
                .AddSingleton<IWallet, Wallet>()
                .AddSingleton<IFiniteStateMachine, FiniteStateMachine>()
                .AddTransient<IGame, Game>();

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            AppSettings options = new();
            configuration.GetSection(nameof(AppSettings)).Bind(options);
            services.AddSingleton(options);

            SymbolData parameters = new();
            configuration.GetSection(nameof(SymbolData)).Bind(parameters);
            services.AddSingleton(parameters);
        }
    }
}
