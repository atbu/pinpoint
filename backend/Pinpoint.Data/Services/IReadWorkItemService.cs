using Pinpoint.Data.Models;

namespace Pinpoint.Data.Services;

public interface IReadWorkItemService
{
    IEnumerable<WorkItem> GetWorkItems();
    WorkItem GetWorkItemById(Guid id);
}