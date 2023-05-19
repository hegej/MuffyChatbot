using DSharpPlus;
using MuffyChatbot;
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

client.AddMuffybot();

var token = source.Token;
await client.ConnectAsync();

while (!token.IsCancellationRequested) {
    await Task.Delay(100);
}

