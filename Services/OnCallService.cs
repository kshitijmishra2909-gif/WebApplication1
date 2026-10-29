using System;

namespace WebApplication1.Services;

public class OnCallService
{
    private readonly Dictionary<string, string> OnCallContactForService;

    private readonly ILogger<OnCallService> _logger;

    public OnCallService(ILogger<OnCallService> logger)
    {
        OnCallContactForService = new();
        _logger = logger;
        OnCallContactForService["svc-payments"] = "+919900112233";
        OnCallContactForService["svc-checkout"] = "+919900445566";
        OnCallContactForService["svc-search"] = "+919900778899";
    }

    public string GetOneCallContactForService(string service)
    {
        if (!OnCallContactForService.ContainsKey(service))
        {
            _logger.LogWarning($"on call contact info not found for service {service}");
            return null;
        }
        return OnCallContactForService[service];
    }
}
