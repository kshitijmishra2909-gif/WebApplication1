using System;
using WebApplication1.Services;

namespace WebApplication1.Models;

public class CriticalNotificationHandler : NotificationHandler
{
    public CriticalNotificationHandler()
    {
    }
    public override void Notify(Incident incident)
    {
        if (incident.Severity == Severity.CRITICAL)
        {
            // notify
        } else
        {
            // pass down to Next if not null;
        }
        
    }

}
