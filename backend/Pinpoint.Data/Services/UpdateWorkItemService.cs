using Pinpoint.Data.DTOs;
using Pinpoint.Data.Helpers;
using Pinpoint.Data.Models;
using Pinpoint.Data.Repositories.WorkItem;

namespace Pinpoint.Data.Services;

public class UpdateWorkItemService : IUpdateWorkItemService
{
    private readonly IWorkItemRepository _repository;
    private readonly ISaveChangesHelper _saveChangesHelper;

    public UpdateWorkItemService(IWorkItemRepository repository, ISaveChangesHelper saveChangesHelper)
    {
        _repository = repository;
        _saveChangesHelper = saveChangesHelper;
    }

    public WorkItem UpdateWorkItem(Guid id, UpdateWorkItemDto dto)
    {
        var workItem = _repository.GetWorkItemById(id);

        workItem.Title = dto.Title;
        workItem.Description = dto.Description;
        workItem.Status = dto.Status;
        
        _saveChangesHelper.SaveChanges();

        return workItem;
    }
}