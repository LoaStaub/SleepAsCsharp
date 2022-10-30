using Discord;
using Discord.Webhook;

namespace DiscordNode;

public class DiscordNode
{
    private readonly DiscordNodeModel _discordNodeModel;

    public DiscordNode(DiscordNodeModel discordNodeModel)
    {
        _discordNodeModel = discordNodeModel;
    }

    public async Task<ulong> SendMessage()
    {
        
        var webhookClient = new DiscordWebhookClient(_discordNodeModel.Url);
        return await webhookClient.SendMessageAsync(
            text: _discordNodeModel.Text, isTTS: false, null, username: _discordNodeModel.Username,
            allowedMentions: AllowedMentions.All, flags: MessageFlags.None
        );
    }
}