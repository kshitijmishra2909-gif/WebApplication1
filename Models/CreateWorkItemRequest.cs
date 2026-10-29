using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

/// <summary>Payload for creating a work item.</summary>
public sealed record CreateWorkItemRequest
{
    /// <summary>The work item's name.</summary>
    [Required, StringLength(120, MinimumLength = 1)]
    public required string Name { get; init; }

    /// <summary>Optional details about the work item.</summary>
    [StringLength(1000)]
    public string? Description { get; init; }
}