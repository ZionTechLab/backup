using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ReportEngine.Core.Models;

namespace ReportEngine.Migrator;

/// <summary>
/// Extracts layout metadata from a Crystal Reports <c>.rpt</c> file into a <see cref="ReportTemplate"/>.
///
/// The Crystal-dependent body is compiled ONLY when the <c>CRYSTAL</c> symbol is defined and the
/// SAP Crystal Reports SDK (CrystalDecisions.CrystalReports.Engine + CrystalDecisions.Shared) is
/// referenced. Without it, <see cref="Extract"/> throws a clear <see cref="PlatformNotSupportedException"/>
/// so the rest of the solution still builds and runs in environments where the SDK is absent.
///
/// Build the real extractor with:  dotnet build -p:DefineConstants=CRYSTAL
/// </summary>
public class RptExtractor
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    /// <summary>Reads a <c>.rpt</c> file and returns its layout as a <see cref="ReportTemplate"/>.</summary>
    public ReportTemplate Extract(string rptPath)
    {
#if CRYSTAL
        var doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        doc.Load(rptPath);

        var template = new ReportTemplate
        {
            Name = Path.GetFileNameWithoutExtension(rptPath),
            PageWidth = 850,
            PageHeight = 1100,
            Sections = new Dictionary<string, ReportSection>()
        };

        foreach (CrystalDecisions.CrystalReports.Engine.Section section in doc.ReportDefinition.Sections)
        {
            string key = MapSection(section.Kind);
            if (!template.Sections.TryGetValue(key, out ReportSection? reportSection))
            {
                reportSection = new ReportSection { Height = 0, Elements = new List<ReportElement>() };
                template.Sections[key] = reportSection;
            }

            foreach (CrystalDecisions.CrystalReports.Engine.ReportObject obj in section.ReportObjects)
            {
                // Crystal positions are in twips; convert to pixels (px = twips / 15).
                var element = new ReportElement
                {
                    X = obj.Left / 15,
                    Y = obj.Top / 15,
                    Width = obj.Width / 15,
                    Height = obj.Height / 15
                };

                switch (obj.Kind)
                {
                    case CrystalDecisions.Shared.ReportObjectKind.FieldObject:
                        var field = (CrystalDecisions.CrystalReports.Engine.FieldObject)obj;
                        element.Type = "field";
                        // DataSource.FormulaName is the bound field reference, e.g. "{Patient.Name}".
                        element.Source = CleanFieldName(field.DataSource?.FormulaName ?? field.Name);
                        element.Font = MapFont(field.Font, field.Color);
                        break;

                    case CrystalDecisions.Shared.ReportObjectKind.TextObject:
                        var text = (CrystalDecisions.CrystalReports.Engine.TextObject)obj;
                        element.Type = "text";
                        element.Value = text.Text;
                        element.Font = MapFont(text.Font, text.Color);
                        break;

                    case CrystalDecisions.Shared.ReportObjectKind.PictureObject:
                        element.Type = "image";
                        element.ImagePath = obj.Name; // resolved/exported separately during migration
                        break;

                    case CrystalDecisions.Shared.ReportObjectKind.LineObject:
                    case CrystalDecisions.Shared.ReportObjectKind.BoxObject:
                        element.Type = "line";
                        break;

                    default:
                        element.Type = "text";
                        break;
                }

                int bottom = element.Y + element.Height;
                if (bottom > reportSection.Height)
                    reportSection.Height = bottom;

                reportSection.Elements.Add(element);
            }
        }

        doc.Close();
        return template;
#else
        throw new PlatformNotSupportedException(
            "RptExtractor was built without the CRYSTAL compilation symbol, so the Crystal Reports SDK " +
            "extraction path is not available. Install the SAP Crystal Reports SDK, reference " +
            "CrystalDecisions.CrystalReports.Engine + CrystalDecisions.Shared, and rebuild with " +
            "-p:DefineConstants=CRYSTAL.");
#endif
    }

    /// <summary>Extracts a <c>.rpt</c> file and writes the resulting template to <paramref name="outputJsonPath"/>.</summary>
    public void ExtractToFile(string rptPath, string outputJsonPath)
    {
        ReportTemplate template = Extract(rptPath);

        string? directory = Path.GetDirectoryName(outputJsonPath);
        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        File.WriteAllText(outputJsonPath, JsonSerializer.Serialize(template, JsonOptions));
    }

#if CRYSTAL
    /// <summary>Maps a Crystal section kind to a template section key.</summary>
    private static string MapSection(CrystalDecisions.Shared.AreaSectionKind kind) => kind switch
    {
        CrystalDecisions.Shared.AreaSectionKind.ReportHeader => "header",
        CrystalDecisions.Shared.AreaSectionKind.PageHeader   => "pageHeader",
        CrystalDecisions.Shared.AreaSectionKind.Detail       => "detail",
        CrystalDecisions.Shared.AreaSectionKind.PageFooter   => "pageFooter",
        CrystalDecisions.Shared.AreaSectionKind.ReportFooter => "footer",
        CrystalDecisions.Shared.AreaSectionKind.GroupHeader  => "pageHeader",
        CrystalDecisions.Shared.AreaSectionKind.GroupFooter  => "pageFooter",
        _ => "detail"
    };

    /// <summary>Maps a Crystal font + colour to a <see cref="FontStyle"/>.</summary>
    private static FontStyle MapFont(System.Drawing.Font font, System.Drawing.Color color) => new()
    {
        Name = font.Name,
        Size = (int)font.SizeInPoints,
        Bold = font.Bold,
        Italic = font.Italic,
        Color = $"#{color.R:X2}{color.G:X2}{color.B:X2}"
    };

    /// <summary>Strips Crystal field decoration, e.g. "{Patient.Name}" -> "Patient.Name".</summary>
    private static string CleanFieldName(string raw) => raw.Trim('{', '}');
#endif
}
