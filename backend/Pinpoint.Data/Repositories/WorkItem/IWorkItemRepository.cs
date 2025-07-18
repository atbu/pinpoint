namespace Pinpoint.Data.Repositories.WorkItem;

public interface IWorkItemRepository
{
    IEnumerable<Models.WorkItem> GetWorkItems();
    Models.WorkItem GetWorkItemById(Guid id);
    Models.WorkItem InsertWorkItem(Models.WorkItem workItem);
    Models.WorkItem UpdateWorkItem(Models.WorkItem workItem);
    void DeleteWorkItem(Guid id);
}