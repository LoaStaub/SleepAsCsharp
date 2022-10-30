using DiscordNode;
using SharedModels.Enums;
using SharedModels.Models;

namespace SleepAsAndroidRestApi.Classes;

internal class SleepMethods
{
    private readonly SleepInteractionModel _sleepInteraction;
    private readonly string _url;
    internal readonly Task TaskRun;

    internal SleepMethods(SleepInteractionModel sleepInteraction, string url)
    {
        _sleepInteraction = sleepInteraction;
        _url = url;
        switch (_sleepInteraction.EventType)
        {
            case Event.sleep_tracking_started:
                TaskRun = SleepTrackingStartedTask();
                break;
            case Event.sleep_tracking_stopped:
                TaskRun = SleepTrackingStoppedTask();
                break;
            case Event.sleep_tracking_paused:
                TaskRun = SleepTrackingPausedTask();
                break;
            case Event.sleep_tracking_resumed:
                TaskRun = SleepTrackingResumedTask();
                break;
            case Event.alarm_snooze_clicked:
                TaskRun = AlarmSnoozeClickedTask();
                break;
            case Event.alarm_snooze_canceled:
                TaskRun = AlarmSnoozeCanceledTask();
                break;
            case Event.time_to_bed_alarm_alert:
                TaskRun = TimeToBedAlarmAlertTask();
                break;
            case Event.alarm_alert_start:
                TaskRun = AlarmAlertStartTask();
                break;
            case Event.alarm_alert_dismiss:
                TaskRun = AlarmAlertDismissTask();
                break;
            case Event.alarm_skip_next:
                TaskRun = AlarmSkipNextTask();
                break;
            case Event.show_skip_next_alarm:
                TaskRun = ShowSkipNextAlarmTask();
                break;
            case Event.rem:
                TaskRun = RemTask();
                break;
            case Event.smart_period:
                TaskRun = SmartPeriodTask();
                break;
            case Event.before_smart_period:
                TaskRun = BeforeSmartPeriodTask();
                break;
            case Event.lullaby_start:
                TaskRun = LullabyStartTask();
                break;
            case Event.lullaby_stop:
                TaskRun = LullabyStopTask();
                break;
            case Event.lullaby_volume_down:
                TaskRun = LullabyVolumeDownTask();
                break;
            case Event.deep_sleep:
                TaskRun = DeepSleepTask();
                break;
            case Event.light_sleep:
                TaskRun = LightSleepTask();
                break;
            case Event.awake:
                TaskRun = AwakeTask();
                break;
            case Event.not_awake:
                TaskRun = NotAwakeTask();
                break;
            case Event.apnea_alarm:
                TaskRun = ApneaAlarmTask();
                break;
            case Event.antisnoring:
                TaskRun = AntisnoringTask();
                break;
            case Event.sound_event_snore:
                TaskRun = SoundEventSnoreTask();
                break;
            case Event.sound_event_talk:
                TaskRun = SoundEventTalkTask();
                break;
            case Event.sound_event_cough:
                TaskRun = SoundEventCoughTask();
                break;
            case Event.sound_event_baby:
                TaskRun = SoundEventBabyTask();
                break;
            case Event.sound_event_laugh:
                TaskRun = SoundEventLaughTask();
                break;
            default:
                TaskRun = ErrorTask();
                break;
        }
    }

    internal async Task ErrorTask()
    {
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, 0);
        await loggingNode.Save();
    }
    
    internal async Task SleepTrackingStartedTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Sleep Tracking gestartet. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task SleepTrackingStoppedTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Sleep Tracking gestoppt. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task SleepTrackingPausedTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Sleep Tracking pausiert. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task SleepTrackingResumedTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Sleep Tracking fortgesetzt. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task AlarmSnoozeClickedTask()
    {
        var unixTimeStamp = Convert.ToInt64(_sleepInteraction.Value1);
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        var dateTimeNow = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Wecker {_sleepInteraction.Value2} für {dateTimeNow:HH:mm} wurde gesnoozed. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task AlarmSnoozeCanceledTask()
    {
        var unixTimeStamp = Convert.ToInt64(_sleepInteraction.Value1);
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        var dateTimeNow = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Der gesnoozede Wecker {_sleepInteraction.Value2} für {dateTimeNow:HH:mm} wurde beendet. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task TimeToBedAlarmAlertTask()
    {
        var unixTimeStamp = Convert.ToInt64(_sleepInteraction.Value1);
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        var dateTimeNow = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Ich sollte schlafen gehen, denn mein Wecker klingelt um {dateTimeNow:HH:mm}. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task AlarmAlertStartTask()
    {
        var unixTimeStamp = Convert.ToInt64(_sleepInteraction.Value1);
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        var dateTimeNow = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Wecker {_sleepInteraction.Value2} für {dateTimeNow:HH:mm} klingelt jetzt. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }

    internal async Task AlarmAlertDismissTask()
    {
        var unixTimeStamp = Convert.ToInt64(_sleepInteraction.Value1);
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        var dateTimeNow = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Wecker {_sleepInteraction.Value2} für {dateTimeNow:HH:mm} wurde regulär beendet. Ich bin Wach. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task AlarmSkipNextTask()
    {
        var unixTimeStamp = Convert.ToInt64(_sleepInteraction.Value1);
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        var dateTimeNow = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Wecker {_sleepInteraction.Value2} für {dateTimeNow:HH:mm} wurde vorzeitig beendet. Ich bin wohl früher aufgestanden. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task ShowSkipNextAlarmTask()
    {
        var unixTimeStamp = Convert.ToInt64(_sleepInteraction.Value1);
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        var dateTimeNow = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Der nächste Alarm ist um {dateTimeNow:HH:mm}, also in einer Stunde? Ich weiß die genaue Funktion dieses Events nicht. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task RemTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Meine REM Schlafphase beginnt jetzt ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task SmartPeriodTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Smartperiode beginnt jetzt ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task BeforeSmartPeriodTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Smartperiode beginnt in 45 Minuten ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task LullabyStartTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Lullaby startet gerade ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task LullabyStopTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Lullaby stoppt gerade. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task LullabyVolumeDownTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Lullaby wird jetzt leiser. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task DeepSleepTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Tiefschlafphase beginnt jetzt. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task LightSleepTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Leichte Schlafphase beginnt jetzt. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task AwakeTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Ich bin wohl gerade aufgewacht. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task NotAwakeTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Ich bin wohl nicht mehr wach. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task ApneaAlarmTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Ich habe wohl grad Apnöen. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task AntisnoringTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Ich schnarche gerade wohl und die Anti Schnarch Funktion wurde getriggert. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task SoundEventSnoreTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Ich schnarche gerade. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task SoundEventTalkTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Ich rede gerade im Schlaf. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task SoundEventCoughTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Ich huste gerade im Schlaf. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task SoundEventBabyTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Babygeschrei wurde erkannt. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
    
    internal async Task SoundEventLaughTask()
    {
        var discordNodeModel = new DiscordNodeModel
        {
            Text = $"Ich lache gerade im Schlaf. ({DateTime.Now:HH:mm})",
            Url = _url,
            Username = _sleepInteraction.User
        };
        var discordNode = new DiscordNode.DiscordNode(discordNodeModel);
        var id = await discordNode.SendMessage();
        var loggingNode = new LoggingNode.LoggingNode(_sleepInteraction, id);
        await loggingNode.Save();
    }
}