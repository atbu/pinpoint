using Pinpoint.Data.Helpers;
using Pinpoint.Data.Models;
using Pinpoint.Data.Repositories.WorkItem;

namespace Pinpoint.Data.Services;

public class CreateWorkItemService : ICreateWorkItemService
{
    private readonly IWorkItemRepository _repository;
    private readonly ISaveChangesHelper _saveChangesHelper;
    
    public CreateWorkItemService(IWorkItemRepository repository, ISaveChangesHelper saveChangesHelper)
    {
        _repository = repository;
        _saveChangesHelper = saveChangesHelper;
    }
    
    public WorkItem Create(WorkItem workItem)
    {
        var workItemToInsert = _repository.InsertWorkItem(workItem);
        
        _saveChangesHelper.SaveChanges();

        return _repository.GetWorkItemById(workItemToInsert.Id);
    }
}