using DSharpPlus;
using DSharpPlus.EventArgs;

namespace MuffyChatbot;

public class Muffybot {


    public void Initialize(DiscordClient client)
    {
        client.MessageCreated += OnMessageCreated;    
    }

    private async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        if (args.Message.Content.StartsWith("ping")) 
        {
            var discordMessage = await client.SendMessageAsync(args.Channel, 
            $"Hey, don't ping me {args.Author.Username}!");
        }
    }  
}
