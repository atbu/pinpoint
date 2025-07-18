using Microsoft.EntityFrameworkCore;

namespace Pinpoint.Data.Repositories.WorkItem;

public class WorkItemRepository : IWorkItemRepository, IDisposable
{
    private readonly Context _context;

    public WorkItemRepository(Context context)
    {
        _context = context;
    }

    public IEnumerable<Models.WorkItem> GetWorkItems()
    {
        return _context.WorkItems.ToList();
    }

    public Models.WorkItem GetWorkItemById(Guid id)
    {
        return _context.WorkItems.Find(id) ?? throw new InvalidOperationException("Work item does not exist.");
    }

    public Models.WorkItem InsertWorkItem(Models.WorkItem workItem)
    {
        var insertWorkItemOperation = _context.WorkItems.Add(workItem);
        return insertWorkItemOperation.Entity;
    }

    public Models.WorkItem UpdateWorkItem(Models.WorkItem workItem)
    {
        _context.Entry(workItem).State = EntityState.Modified;
        return _context.WorkItems.Find(workItem) ?? throw new InvalidOperationException("Work item does not exist.");
    }

    public void DeleteWorkItem(Guid id)
    {
        Models.WorkItem workItem = _context.WorkItems.Find(id) ?? throw new InvalidOperationException("Work item does not exist.");
        _context.WorkItems.Remove(workItem);
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        this._disposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}