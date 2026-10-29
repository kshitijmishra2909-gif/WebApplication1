namespace WebApplication1.Repositories;

/// <summary>Defines storage operations for work items.</summary>
public interface IWorkItemRepository
{
    /// <summary>Adds a work item to storage.</summary>
    WorkItem Add(string name, string? description);

    /// <summary>Finds a work item by its identifier.</summary>
    WorkItem? GetById(Guid id);
}