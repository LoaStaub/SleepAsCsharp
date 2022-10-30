using Microsoft.AspNetCore.Mvc;
using SharedModels.Enums;
using SharedModels.Models;
using SleepAsAndroidRestApi.Classes;
using Microsoft.Extensions.Configuration;

namespace SleepAsAndroidRestApi.Controllers;

public class SleepController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public SleepController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [Route("sleep/action")]
    [HttpPost]
    public async Task<bool> Action(string user, string key, [FromBody] SleepAsAndroid model)
    {
        if (key != "lstb12")
        {
            return false;
        }
        var sleepInteraction = new SleepInteractionModel
        {
            EventType = Enum.Parse<Event>(model.@event),
            User = user,
            Value1 = model.value1,
            Value2 = model.value2,
            Value3 = model.value3
        };
        var discordWebhookUrl = _configuration.GetValue<string>("Settings:DiscordWebhook");
        var sleepMethod = new SleepMethods(sleepInteraction, discordWebhookUrl);
        await sleepMethod.TaskRun;
        return true;
    }
}