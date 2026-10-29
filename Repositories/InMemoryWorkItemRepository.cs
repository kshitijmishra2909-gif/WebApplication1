using System.Collections.Concurrent;

namespace WebApplication1.Repositories;

internal sealed class InMemoryWorkItemRepository : IWorkItemRepository
{
    private readonly ConcurrentDictionary<Guid, WorkItem> _workItems = new();

    public WorkItem Add(string name, string? description)
    {
        var workItem = new WorkItem(Guid.NewGuid(), name, description, DateTimeOffset.UtcNow);
        _workItems[workItem.Id] = workItem;
        return workItem;
    }

    public WorkItem? GetById(Guid id)
    {
        return _workItems.TryGetValue(id, out var workItem) ? workItem : null;
    }
}