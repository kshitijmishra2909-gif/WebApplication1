namespace WebApplication1.Models;

/// <summary>A work item returned by the API.</summary>
public sealed record WorkItemResponse(
    Guid Id,
    string Name,
    string? Description,
    DateTimeOffset CreatedAt);