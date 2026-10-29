using System;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class IncidentService : IIncidentService
{
    private readonly NotificationHandler _notificationHandler; 
    private readonly ILogger<IncidentService> _logger;

    public IncidentService(ILogger<IncidentService> logger)
    {
        _notificationHandler = new CriticalNotificationHandler();
        _logger = logger;
    }
    
    public Incident CreateIncident(Alert alert)
    {
        //  create incident
        var incident = new Incident(alert.ServiceId, alert.Severity);

        // notify
        _notificationHandler.Notify(incident);

        return incident;
    }

}
