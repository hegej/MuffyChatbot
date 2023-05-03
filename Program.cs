using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var source = new CancellationTokenSource();

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true)
    .AddUserSecrets(typeof(Program).Assembly, true)
    .Build();

var client = new DiscordClient(new DiscordConfiguration {
    Token = config["discordtoken"],
    TokenType = TokenType.Bot
});

client.MessageCreated += async (client, args) => {

    if (args.Message.Content.StartsWith("ping")) {
        var discordMessage = await client.SendMessageAsync(args.Channel, 
        $"Hey, don't ping me {args.Author.Username}!");
    }
        
};

var token = source.Token;
await client.ConnectAsync();

while (!token.IsCancellationRequested) {
    await Task.Delay(100);
}

