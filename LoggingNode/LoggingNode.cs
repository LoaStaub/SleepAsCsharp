using LiteDB;
using SharedModels.Models;

namespace LoggingNode;

public class LoggingNode
{
    private readonly SleepLog _sleepLog;
    private readonly LiteDatabase _database;
    public LoggingNode(SleepInteractionModel sleepInteractionModel, ulong discordMessageId)
    {
        _sleepLog = new SleepLog
        {
            User = sleepInteractionModel.User,
            Value1 = sleepInteractionModel.Value1,
            Value2 = sleepInteractionModel.Value2,
            Value3 = sleepInteractionModel.Value3,
            EventType = sleepInteractionModel.EventType,
            EventName = sleepInteractionModel.EventType.ToString(),
            DiscordMessageId = discordMessageId,
            CreateDateTime = DateTime.Now
        };
        _database = new LiteDatabase("Filename=SleepDatabase.db;connection=shared");
    }

    public async Task Save()
    {
        var collection = _database.GetCollection<SleepLog>("SleepLogs");
        collection.Insert(_sleepLog);
    }

    public async Task Error()
    {
        var error = new ErrorLog
        {
            Error = "ERROR",
            CreateDateTime = DateTime.Now
        };
        var collection = _database.GetCollection<ErrorLog>("Errors");
        collection.Insert(error);
    }
}