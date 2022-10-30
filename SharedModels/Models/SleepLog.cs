using SharedModels.Enums;

namespace SharedModels.Models;

public class SleepLog
{
    public DateTime CreateDateTime { get; set; }
    public Event EventType { get; set; }
    public string EventName { get; set; }
    public string? Value1 { get; set; }
    public string? Value2 { get; set; }
    public string? Value3 { get; set; }
    public string User { get; set; }
    public ulong DiscordMessageId { get; set; }
}