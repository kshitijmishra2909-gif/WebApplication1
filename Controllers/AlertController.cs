using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

/// <summary>Creates and retrieves work items.</summary>
[ApiController]
[Route("alert")]
public sealed class AlertsController : ControllerBase
{
    private readonly IIncidentService _incidentService;
    private readonly ILogger<AlertsController> _logger;

    /// <summary>Creates the work-items controller.</summary>
    public AlertsController(
        IIncidentService incidentService,
        ILogger<AlertsController> logger)
    {
        _incidentService = incidentService;
        _logger = logger;
    }

    /// <summary>Creates a work item.</summary>
    [HttpPost]
    [ProducesResponseType<Incident>(StatusCodes.Status201Created)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public ActionResult<Incident> Create([FromBody] Alert alert)
    {
        var incident = _incidentService.CreateIncident(alert);

        _logger.LogInformation($"Created incident {incident.IncidentId}");

        return CreatedAtAction("CreateAlert", new { id = incident.IncidentId }, incident);
    }

}