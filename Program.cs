using SharpCord;
using SharpCord.Registry;

using SharpCord_Bot_Example.Events;
using System.Reflection;

namespace SharpCordBotTesting
{
    public class Program
    {
        private string _botToken = "BOT_TOKEN_HERE";
        public static DiscordClient DiscordClient { get; set; }

        public static void Main() => new Program().ConfigureBot().GetAwaiter().GetResult();

        public async Task ConfigureBot()
        {
            IEnumerable<Type> modules = GetModules();

            EventRegistry.RegisterEventsFrom<Events>();
            CommandRegistry.RegisterModules([.. modules]);

            Login();

            await Task.Delay(-1);
        }

        private async void Login()
        {
            DiscordClient = new DiscordClient(_botToken, SharpCord.Models.GatewayIntent.All);

            await DiscordClient.LoginAsync();
        }

        private IEnumerable<Type> GetModules()
        {
            IEnumerable<Type> modules = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.IsClass && x.IsPublic && !x.IsAbstract && x.Namespace == "SharpCord_Bot_Example.Modules");

            return modules;
        }
    }
}