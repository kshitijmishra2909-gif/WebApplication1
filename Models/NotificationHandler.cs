using System;
using WebApplication1.Services;

namespace WebApplication1.Models;

public abstract class NotificationHandler
{
    public abstract void Notify(Incident incident);
    public NotificationHandler Next;
}
