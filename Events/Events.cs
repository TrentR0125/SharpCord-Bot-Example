using SharpCord.Attributes;
using SharpCord.Models;

namespace SharpCord_Bot_Example.Events
{
    public class Events
    {
        [EventHandler(DiscordEvents.Ready)]
        public void OnReadyEvent() => Console.WriteLine("Bot is online!");
    }
}
