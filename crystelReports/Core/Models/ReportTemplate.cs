using System.Collections.Generic;

namespace ReportEngine.Core.Models;

/// <summary>
/// Root model for a report layout. Deserialized from a JSON template file
/// (or produced by the RPT Migrator) and consumed by the rendering engine.
/// </summary>
public class ReportTemplate
{
    public string Name { get; set; } = "";

    /// <summary>Page width in pixels.</summary>
    public int PageWidth { get; set; } = 850;

    /// <summary>Page height in pixels.</summary>
    public int PageHeight { get; set; } = 1100;

    /// <summary>
    /// Sections keyed by name: "header", "pageHeader", "detail", "pageFooter", "footer".
    /// Only "detail" is repeated per data row; the rest render once.
    /// </summary>
    public Dictionary<string, ReportSection> Sections { get; set; } = new();
}
