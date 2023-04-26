using DSharpPlus;

var client = new DiscordClient(new DiscordConfiguration {
    Token = "MY TOKEN",
    TokenType = TokenType.Bot
});

client.MessageCreated += async (client, args) => {

    if (args.Message.Content.StartsWith("ping")) {
        await client.SendMessageAsync(args.Channel, "pong");
    }
        
};

await client.ConnectAsync();
await Task.Delay(-1);



