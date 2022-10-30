using SharedModels.Enums;

namespace SharedModels.Models;

public class SleepInteractionModel
{
    public Event EventType { get; set; }
    public string? Value1 { get; set; }
    public string? Value2 { get; set; }
    public string? Value3 { get; set; }
    public string User { get; set; }
}