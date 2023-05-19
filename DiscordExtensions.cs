using DSharpPlus;

namespace MuffyChatbot;

public static class DiscordExtensions {

    private static MuffyBot? _Bot;
    public static DiscordClient AddMuffybot(this DiscordClient client)
    {
        _Bot = new MuffyBot();
        _Bot.Initialize(client);

        return client;
    }

}