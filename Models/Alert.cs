using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Alert
{
    /// <summary>ServiceId</summary>
    [Required, StringLength(120, MinimumLength = 1)]
    public string ServiceId;
    /// <summary>The work item's name.</summary>
    [Required, StringLength(120, MinimumLength = 1)]
    public string Title;
    public string DedupKey; 
    public Severity Severity;

    public Alert(string serviceId, string title, string dedupKey, Severity severity) {
        ServiceId = serviceId;
        Title = title;
        DedupKey = dedupKey;
        Severity = severity;
    }
}
