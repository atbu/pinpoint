using Microsoft.AspNetCore.Mvc;
using Pinpoint.Data.DTOs;
using Pinpoint.Data.Models;
using Pinpoint.Data.Services;

namespace Pinpoint.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkItemController : Controller
{
    private readonly ICreateWorkItemService _createWorkItemService;
    private readonly IReadWorkItemService _readWorkItemService;
    private readonly IUpdateWorkItemService _updateWorkItemService;
    private readonly IDeleteWorkItemService _deleteWorkItemService;

    public WorkItemController(ICreateWorkItemService createWorkItemService, IReadWorkItemService readWorkItemService,
        IUpdateWorkItemService updateWorkItemService, IDeleteWorkItemService deleteWorkItemService)
    {
        _createWorkItemService = createWorkItemService;
        _readWorkItemService = readWorkItemService;
        _updateWorkItemService = updateWorkItemService;
        _deleteWorkItemService = deleteWorkItemService;
    }

    [HttpPost]
    [Route("")]
    public IActionResult CreateWorkItem([FromBody] WorkItem workItem)
    {
        return Ok(_createWorkItemService.Create(workItem));
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetWorkItems()
    {
        return Ok(_readWorkItemService.GetWorkItems());
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetWorkItem(Guid id)
    {
        return Ok(_readWorkItemService.GetWorkItemById(id));
    }

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult UpdateWorkItem(Guid id, [FromBody] UpdateWorkItemDto dto)
    {
        return Ok(_updateWorkItemService.UpdateWorkItem(id, dto));
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult DeleteWorkItem(Guid id)
    {
        _deleteWorkItemService.DeleteWorkItem(id);
        return Ok();
    }
}