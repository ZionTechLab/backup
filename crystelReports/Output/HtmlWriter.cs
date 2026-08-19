using System.IO;
using System.Net;
using System.Text;

namespace ReportEngine.Output;

/// <summary>
/// Wraps rendered section HTML in a full HTML document (with base CSS) and writes the
/// result to a string, a file, or a stream. This type deliberately has no dependency on
/// the Core models so the rendering and output concerns stay decoupled.
/// </summary>
public static class HtmlWriter
{
    /// <summary>Wraps section <paramref name="bodyHtml"/> in a complete HTML document.</summary>
    public static string WrapDocument(string bodyHtml, int pageWidth, string title = "Report")
    {
        var sb = new StringBuilder();
        sb.AppendLine("<!DOCTYPE html>");
        sb.AppendLine("<html lang=\"en\">");
        sb.AppendLine("<head>");
        sb.AppendLine("  <meta charset=\"utf-8\" />");
        sb.AppendLine($"  <title>{WebUtility.HtmlEncode(title)}</title>");
        sb.AppendLine("  <style>");
        sb.AppendLine("    body { margin: 0; font-family: Arial, sans-serif; }");
        sb.AppendLine($"    .report-page {{ width: {pageWidth}px; margin: auto; }}");
        sb.AppendLine("    .section { position: relative; width: 100%; }");
        sb.AppendLine("    .element { position: absolute; overflow: hidden; white-space: nowrap; }");
        sb.AppendLine("  </style>");
        sb.AppendLine("</head>");
        sb.AppendLine("<body>");
        sb.AppendLine("  <div class=\"report-page\">");
        sb.Append(bodyHtml);
        sb.AppendLine();
        sb.AppendLine("  </div>");
        sb.AppendLine("</body>");
        sb.AppendLine("</html>");
        return sb.ToString();
    }

    /// <summary>Writes <paramref name="html"/> to <paramref name="outputPath"/> (creating directories as needed).</summary>
    public static void WriteToFile(string html, string outputPath)
    {
        string? directory = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        File.WriteAllText(outputPath, html, Encoding.UTF8);
    }

    /// <summary>Writes <paramref name="html"/> to <paramref name="stream"/>; the stream is left open.</summary>
    public static void WriteToStream(string html, Stream stream)
    {
        using var writer = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), leaveOpen: true);
        writer.Write(html);
        writer.Flush();
    }
}
