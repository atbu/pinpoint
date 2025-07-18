using Pinpoint.Data.Models;
using Pinpoint.Data.Repositories.WorkItem;

namespace Pinpoint.Data.Services;

public class ReadWorkItemService : IReadWorkItemService
{
    private readonly IWorkItemRepository _repository;

    public ReadWorkItemService(IWorkItemRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<WorkItem> GetWorkItems()
    {
        return _repository.GetWorkItems();
    }

    public WorkItem GetWorkItemById(Guid id)
    {
        return _repository.GetWorkItemById(id);
    }
}