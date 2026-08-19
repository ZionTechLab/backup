using System;

namespace ReportEngine.Core;

/// <summary>
/// Replaces expression tokens inside static text values.
/// Supported tokens: {page}, {totalPages}, {date}, {datetime}, {reportName}.
/// </summary>
public class ExpressionEvaluator
{
    public int CurrentPage { get; set; } = 1;
    public int TotalPages { get; set; } = 1;
    public string ReportName { get; set; } = "";

    /// <summary>The clock used for {date}/{datetime}. Overridable for deterministic tests.</summary>
    public Func<DateTime> Now { get; set; } = () => DateTime.Now;

    public string Evaluate(string? text)
    {
        if (string.IsNullOrEmpty(text))
            return "";

        DateTime now = Now();
        return text
            .Replace("{page}", CurrentPage.ToString())
            .Replace("{totalPages}", TotalPages.ToString())
            .Replace("{datetime}", now.ToString("dd/MM/yyyy HH:mm:ss"))
            .Replace("{date}", now.ToString("dd/MM/yyyy"))
            .Replace("{reportName}", ReportName);
    }
}
