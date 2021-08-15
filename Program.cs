using Microsoft.Extensions.DependencyInjection;
using SlotMachine.Ports;
using SlotMachine.StateMachine;
using SlotMachine.Calculations;
using SlotMachine.Slots;

namespace SlotMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*var slotsGenerator = new SlotsGenerator(3, 4);
            var wallet = new Wallet();
            var finiteStateMachine = new FiniteStateMachine(wallet, slotsGenerator);

            var serviceProvider = new ServiceCollection();
            serviceProvider.AddSingleton(slotsGenerator);
            serviceProvider.AddSingleton(wallet);
            serviceProvider.AddSingleton(finiteStateMachine);
            serviceProvider.BuildServiceProvider();*/

            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISlotsGenerator, SlotsGenerator>()
                .AddSingleton<IWallet, Wallet>()
                .AddSingleton<IFiniteStateMachine, FiniteStateMachine>()
                .AddSingleton<IGame, Game>()
                .BuildServiceProvider();

            serviceProvider.GetService<IGame>()
                .StartGame();
        }     
    }
}
