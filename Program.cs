using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var source = new CancellationTokenSource();

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true)
    .Build();

var client = new DiscordClient(new DiscordConfiguration {
    Token = config["discordtoken"],
    TokenType = TokenType.Bot
});

client.MessageCreated += async (client, args) => {

    if (args.Message.Content.StartsWith("ping")) {
        await client.SendMessageAsync(args.Channel, "pong");
    }
        
};

var token = source.Token;
await client.ConnectAsync();

while (!token.IsCancellationRequested) {
    await Task.Delay(100);
}

