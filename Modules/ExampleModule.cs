using SharpCord.Attributes;
using SharpCord.Interactions;

namespace SharpCord_Bot_Example.Modules
{
    public class ExampleModule
    {

        [Command("example", GuildIdRaw = "GUILD_ID_HERE")]
        public async Task ExampleCommandHandler(Interaction i)
        {
            await i.ReplyAsync("Hello this is a SharpCord command example!");
        }
    }
}
