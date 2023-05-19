using DSharpPlus;
using DSharpPlus.EventArgs;

namespace MuffyChatbot;

public class MuffyBot {


    public void Initialize(DiscordClient client)
    {
        client.MessageCreated += OnMessageCreated;    
    }

    private HashSet<string> _UsersAcknowledged = new();

    private async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        if (args.Message.Content.StartsWith("ping")) 
        {
            if (_UsersAcknowledged.Contains(args.Author.Username))
            {
                var discordMessage = await client.SendMessageAsync(args.Channel, 
                $"Stop bugging me {args.Author.Username}");
            } else {
                _UsersAcknowledged.Add(args.Author.Username);
                var discordMessage = await client.SendMessageAsync(args.Channel, 
                $"Hey, don't ping me {args.Author.Username}!");
            }
        }
    }  
}
