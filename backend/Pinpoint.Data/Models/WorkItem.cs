namespace Pinpoint.Data.Models;

public class WorkItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Status Status { get; set; } = Status.New;
    public DateTime CreatedAt { get; set; }
}