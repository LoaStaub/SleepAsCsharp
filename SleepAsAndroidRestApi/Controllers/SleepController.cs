using Microsoft.AspNetCore.Mvc;
using SharedModels.Enums;
using SharedModels.Models;
using SleepAsAndroidRestApi.Classes;

namespace SleepAsAndroidRestApi.Controllers;

public class SleepController : ControllerBase
{
    [Route("sleep/action")]
    [HttpPost]
    public async Task Action(string user, string key, [FromBody] SleepAsAndroid model)
    {
        if (key != "lstb12")
        {
            return;
        }
        var sleepInteraction = new SleepInteractionModel
        {
            EventType = Enum.Parse<Event>(model.@event),
            User = user,
            Value1 = model.value1,
            Value2 = model.value2,
            Value3 = model.value3
        };
        var sleepMethod = new SleepMethods(sleepInteraction, "https://discord.com/api/webhooks/887711907409186826/xCOsI5RsoRyYgFikWsjHFiCAiPWHhSMvk1NJlqHIMZpxBPnfgC1hCsPDEQefYynPn6fI");
        await sleepMethod.TaskRun;
    }
}