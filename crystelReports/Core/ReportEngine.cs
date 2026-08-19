using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.Json;
using ReportEngine.Core.Models;
using ReportEngine.Output;

namespace ReportEngine.Core;

/// <summary>
/// Loads a report template (from JSON or an in-memory model) plus a <see cref="DataTable"/>
/// and produces a complete HTML document.
/// </summary>
public class ReportEngine
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    /// <summary>Loads and deserializes a JSON template from disk, then renders it against <paramref name="data"/>.</summary>
    public string Render(string templatePath, DataTable data)
    {
        if (!File.Exists(templatePath))
            throw new FileNotFoundException($"Template not found: {templatePath}", templatePath);

        string json = File.ReadAllText(templatePath);
        ReportTemplate template = JsonSerializer.Deserialize<ReportTemplate>(json, JsonOptions)
            ?? throw new InvalidOperationException($"Template could not be parsed: {templatePath}");

        return Render(template, data);
    }

    /// <summary>Renders an in-memory template against <paramref name="data"/> and returns a full HTML document.</summary>
    public string Render(ReportTemplate template, DataTable data)
    {
        ArgumentNullException.ThrowIfNull(template);
        ArgumentNullException.ThrowIfNull(data);

        var evaluator = new ExpressionEvaluator
        {
            ReportName = template.Name,
            CurrentPage = 1,
            TotalPages = 1
        };
        var renderer = new SectionRenderer(new FieldResolver(), evaluator);

        var body = new StringBuilder();

        // 1-3: static bands render once.
        AppendSection(body, renderer, template, "header");
        AppendSection(body, renderer, template, "pageHeader");

        // 4: detail band repeats per data row.
        if (template.Sections.TryGetValue("detail", out ReportSection? detail) && detail is not null)
        {
            foreach (DataRow row in data.Rows)
                body.Append(renderer.Render(detail, row));
        }

        // 5-6: static footers render once.
        AppendSection(body, renderer, template, "pageFooter");
        AppendSection(body, renderer, template, "footer");

        return HtmlWriter.WrapDocument(body.ToString(), template.PageWidth, template.Name);
    }

    private static void AppendSection(StringBuilder body, SectionRenderer renderer, ReportTemplate template, string key)
    {
        if (template.Sections.TryGetValue(key, out ReportSection? section) && section is not null)
            body.Append(renderer.Render(section));
    }
}
