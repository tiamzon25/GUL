namespace GUL.Shared.Configuration;

public record Supabase
{
    public string Url { get; set; }
    public string ApiKey { get; set; }
}
