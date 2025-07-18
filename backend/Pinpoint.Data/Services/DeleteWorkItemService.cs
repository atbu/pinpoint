using Pinpoint.Data.Helpers;
using Pinpoint.Data.Repositories.WorkItem;

namespace Pinpoint.Data.Services;

public class DeleteWorkItemService : IDeleteWorkItemService
{
    private readonly IWorkItemRepository _repository;
    private readonly ISaveChangesHelper _saveChangesHelper;
    
    public DeleteWorkItemService(IWorkItemRepository repository, ISaveChangesHelper saveChangesHelper)
    {
        _repository = repository;
        _saveChangesHelper = saveChangesHelper;
    }
    
    public void DeleteWorkItem(Guid id)
    {
        _repository.DeleteWorkItem(id);
        _saveChangesHelper.SaveChanges();
    }
}