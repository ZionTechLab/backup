using System.Collections.Generic;

namespace ReportEngine.Core.Models;

/// <summary>A band of the report (header / detail / footer) holding absolutely positioned elements.</summary>
public class ReportSection
{
    /// <summary>Section height in pixels.</summary>
    public int Height { get; set; }

    public List<ReportElement> Elements { get; set; } = new();
}
