using System;
using System.Data;
using System.Globalization;

namespace ReportEngine.Core;

/// <summary>
/// Resolves a field element's <c>Source</c> to a string value from a <see cref="DataRow"/>.
/// </summary>
public class FieldResolver
{
    /// <summary>
    /// Returns the string value for <paramref name="source"/> from <paramref name="row"/>.
    /// Matching is case-insensitive. Nulls and missing columns yield an empty string.
    /// An optional "Column:format" suffix applies a format string to <see cref="IFormattable"/>
    /// values (e.g. "PatientDOB:dd/MM/yyyy", "Amount:N2").
    /// </summary>
    public string Resolve(string? source, DataRow row)
    {
        if (string.IsNullOrWhiteSpace(source) || row is null)
            return "";

        // Split an optional format suffix: "Column:format".
        string column = source;
        string? format = null;
        int idx = source.IndexOf(':');
        if (idx > 0)
        {
            column = source.Substring(0, idx);
            format = source.Substring(idx + 1);
        }

        string? actualColumn = ResolveColumnName(row.Table, column);
        if (actualColumn is null)
            return "";

        object value = row[actualColumn];
        if (value is null || value == DBNull.Value)
            return "";

        if (!string.IsNullOrEmpty(format) && value is IFormattable formattable)
            return formattable.ToString(format, CultureInfo.CurrentCulture);

        return value.ToString() ?? "";
    }

    /// <summary>Returns the table's actual column name matching <paramref name="name"/> case-insensitively, or null.</summary>
    private static string? ResolveColumnName(DataTable table, string name)
    {
        foreach (DataColumn col in table.Columns)
        {
            if (string.Equals(col.ColumnName, name, StringComparison.OrdinalIgnoreCase))
                return col.ColumnName;
        }
        return null;
    }
}
