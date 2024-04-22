namespace GUL.Shared.Configuration;

public record Logging
{
    public HoneyComb HoneyComb { get; set; } = new();
}