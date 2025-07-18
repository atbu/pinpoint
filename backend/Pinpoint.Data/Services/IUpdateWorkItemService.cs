using Pinpoint.Data.DTOs;
using Pinpoint.Data.Models;

namespace Pinpoint.Data.Services;

public interface IUpdateWorkItemService
{
    WorkItem UpdateWorkItem(Guid id, UpdateWorkItemDto dto);
}