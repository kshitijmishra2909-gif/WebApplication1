namespace WebApplication1.Repositories;

/// <summary>A work item stored by the repository.</summary>
public sealed record WorkItem
{
    /// <summary>Creates a stored work item.</summary>
    public WorkItem(Guid id, string name, string? description, DateTimeOffset createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }

    /// <summary>The work item's identifier.</summary>
    public Guid Id { get; init; }

    /// <summary>The work item's name.</summary>
    public string Name { get; init; }

    /// <summary>Optional details about the work item.</summary>
    public string? Description { get; init; }

    /// <summary>The time the work item was created.</summary>
    public DateTimeOffset CreatedAt { get; init; }
}