namespace ReportEngine.Core.Models;

/// <summary>
/// A single positioned element inside a section.
///
/// Note: the spec sketch listed separate FieldElement/TextElement/ImageElement files,
/// but the Phase 2 model code and the JSON template format both use a single flat element
/// with a <see cref="Type"/> discriminator ("text" | "field" | "image" | "line"). A unified
/// class keeps System.Text.Json (de)serialization simple (no polymorphic converter required),
/// so the subtype-specific properties live here and are populated based on <see cref="Type"/>.
/// </summary>
public class ReportElement
{
    /// <summary>One of: "text", "field", "image", "line".</summary>
    public string Type { get; set; } = "text";

    /// <summary>Left offset in pixels (absolute within the section).</summary>
    public int X { get; set; }

    /// <summary>Top offset in pixels (absolute within the section).</summary>
    public int Y { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }

    public FontStyle? Font { get; set; }

    /// <summary>Static text content (Type == "text"). May contain expression tokens like {page}.</summary>
    public string? Value { get; set; }

    /// <summary>
    /// Data column to bind to (Type == "field"). Supports an optional "Column:format" suffix,
    /// e.g. "PatientDOB:dd/MM/yyyy".
    /// </summary>
    public string? Source { get; set; }

    /// <summary>Image URL or path (Type == "image").</summary>
    public string? ImagePath { get; set; }
}

/// <summary>Font / colour styling applied to a text or field element.</summary>
public class FontStyle
{
    public string Name { get; set; } = "Arial";
    public int Size { get; set; } = 10;
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public string Color { get; set; } = "#000000";
}
