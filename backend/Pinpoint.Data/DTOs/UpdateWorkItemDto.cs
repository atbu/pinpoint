using Pinpoint.Data.Models;

namespace Pinpoint.Data.DTOs;

public class UpdateWorkItemDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Status Status { get; set; } = Status.New;
}