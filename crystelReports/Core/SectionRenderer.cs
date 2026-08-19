using System.Data;
using System.Net;
using System.Text;
using ReportEngine.Core.Models;

namespace ReportEngine.Core;

/// <summary>
/// Renders a single <see cref="ReportSection"/> (optionally bound to a <see cref="DataRow"/>)
/// into an absolutely-positioned HTML <c>&lt;div&gt;</c>.
/// </summary>
public class SectionRenderer
{
    private readonly FieldResolver _fieldResolver;
    private readonly ExpressionEvaluator _expressionEvaluator;

    public SectionRenderer(FieldResolver fieldResolver, ExpressionEvaluator expressionEvaluator)
    {
        _fieldResolver = fieldResolver;
        _expressionEvaluator = expressionEvaluator;
    }

    /// <summary>Renders the section. Pass <paramref name="row"/> for data-bound (detail) sections.</summary>
    public string Render(ReportSection section, DataRow? row = null)
    {
        var sb = new StringBuilder();
        sb.Append($"<div class=\"section\" style=\"position:relative;height:{section.Height}px;\">");
        foreach (ReportElement element in section.Elements)
            sb.Append(RenderElement(element, row));
        sb.Append("</div>");
        return sb.ToString();
    }

    private string RenderElement(ReportElement element, DataRow? row)
    {
        var style = new StringBuilder();
        style.Append($"position:absolute;left:{element.X}px;top:{element.Y}px;");
        style.Append($"width:{element.Width}px;height:{element.Height}px;");
        style.Append(FontCss(element.Font));

        string type = (element.Type ?? "text").ToLowerInvariant();
        string content;
        switch (type)
        {
            case "field":
                content = WebUtility.HtmlEncode(row is null ? "" : _fieldResolver.Resolve(element.Source, row));
                break;
            case "image":
                content = $"<img src=\"{WebUtility.HtmlEncode(element.ImagePath ?? "")}\" " +
                          $"style=\"width:{element.Width}px;height:{element.Height}px;\" alt=\"\" />";
                break;
            case "line":
                // A line is drawn as a top border on the (typically 1px-high) element box.
                style.Append("border-top:1px solid #000000;");
                content = "";
                break;
            case "text":
            default:
                content = WebUtility.HtmlEncode(_expressionEvaluator.Evaluate(element.Value));
                break;
        }

        return $"<div class=\"element\" style=\"{style}\">{content}</div>";
    }

    private static string FontCss(FontStyle? font)
    {
        if (font is null)
            return "";

        var css = new StringBuilder();
        css.Append($"font-family:{font.Name};font-size:{font.Size}px;color:{font.Color};");
        if (font.Bold) css.Append("font-weight:bold;");
        if (font.Italic) css.Append("font-style:italic;");
        return css.ToString();
    }
}
