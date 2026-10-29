using System;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IIncidentService
{
    public Incident CreateIncident(Alert alert);
}
