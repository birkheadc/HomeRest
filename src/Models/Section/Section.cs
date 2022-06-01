namespace HomeRest.Models;

public record Section
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Subtitle { get; init; }
    public string Body { get; init; }
}