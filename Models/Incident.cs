using System;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class Incident
{
    public string IncidentId;
    public string ServiceId;
    public Severity Severity;
    public Status Status;
    public NotificationStatus NotificationStatus;

    public Incident(string serviceId, Severity severity)
    {
        // create new id 
        IncidentId = Guid.NewGuid().ToString();

        ServiceId = serviceId;
        Severity = severity;
    }
}
