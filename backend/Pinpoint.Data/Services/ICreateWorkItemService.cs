using Pinpoint.Data.Models;

namespace Pinpoint.Data.Services;

public interface ICreateWorkItemService
{
    WorkItem Create(WorkItem workItem);
}