using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

/// <summary>Creates and retrieves work items.</summary>
[ApiController]
[Route("api/work-items")]
public sealed class WorkItemsController : ControllerBase
{
    private readonly IWorkItemRepository _repository;
    private readonly ILogger<WorkItemsController> _logger;

    /// <summary>Creates the work-items controller.</summary>
    public WorkItemsController(
        IWorkItemRepository repository,
        ILogger<WorkItemsController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <summary>Creates a work item.</summary>
    [HttpPost]
    [ProducesResponseType<WorkItemResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public ActionResult<WorkItemResponse> Create(CreateWorkItemRequest request)
    {
        var workItem = _repository.Add(request.Name, request.Description);
        var response = ToResponse(workItem);

        _logger.LogInformation("Created work item {WorkItemId}", workItem.Id);

        return CreatedAtAction(nameof(GetById), new { id = workItem.Id }, response);
    }

    /// <summary>Gets a work item by its identifier.</summary>
    [HttpGet("{id:guid}", Name = nameof(GetById))]
    [ProducesResponseType<WorkItemResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<WorkItemResponse> GetById(Guid id)
    {
        var workItem = _repository.GetById(id);
        return workItem is null ? NotFound() : Ok(ToResponse(workItem));
    }

    private static WorkItemResponse ToResponse(WorkItem workItem)
    {
        return new WorkItemResponse(
            workItem.Id,
            workItem.Name,
            workItem.Description,
            workItem.CreatedAt);
    }
}