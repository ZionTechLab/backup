using System;
using System.Data;
using System.Globalization;
using ReportEngine.Core;
using Xunit;

namespace ReportEngine.Tests;

public class FieldResolverTests
{
    private static DataRow MakeRow()
    {
        var table = new DataTable();
        table.Columns.Add("PatientName", typeof(string));
        table.Columns.Add("PatientDOB", typeof(DateTime));
        table.Columns.Add("Balance", typeof(decimal));
        table.Columns.Add("MiddleName", typeof(string));

        DataRow row = table.NewRow();
        row["PatientName"] = "Alice Fernando";
        row["PatientDOB"] = new DateTime(1985, 3, 12);
        row["Balance"] = 1234.5m;
        row["MiddleName"] = DBNull.Value;
        table.Rows.Add(row);
        return row;
    }

    private readonly FieldResolver _resolver = new();

    [Fact]
    public void Resolves_Plain_Column_Value()
    {
        Assert.Equal("Alice Fernando", _resolver.Resolve("PatientName", MakeRow()));
    }

    [Fact]
    public void Matches_Column_Case_Insensitively()
    {
        Assert.Equal("Alice Fernando", _resolver.Resolve("patientNAME", MakeRow()));
    }

    [Fact]
    public void Missing_Column_Returns_Empty()
    {
        Assert.Equal("", _resolver.Resolve("DoesNotExist", MakeRow()));
    }

    [Fact]
    public void Null_DbValue_Returns_Empty()
    {
        Assert.Equal("", _resolver.Resolve("MiddleName", MakeRow()));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Null_Or_Blank_Source_Returns_Empty(string? source)
    {
        Assert.Equal("", _resolver.Resolve(source, MakeRow()));
    }

    [Fact]
    public void Applies_Date_Format_Suffix()
    {
        // "/" in a .NET custom date format is the culture's date separator, so compute
        // the expected value with the same culture the resolver uses (CurrentCulture).
        string expected = new DateTime(1985, 3, 12).ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
        Assert.Equal(expected, _resolver.Resolve("PatientDOB:dd/MM/yyyy", MakeRow()));
    }

    [Fact]
    public void Applies_Numeric_Format_Suffix()
    {
        // CultureInfo.CurrentCulture is used; assert on a culture-invariant shape instead of exact separators.
        string result = _resolver.Resolve("Balance:N2", MakeRow());
        Assert.Contains("234", result);
        Assert.EndsWith("50", result.Replace(",", "").Replace(".", ""));
    }
}
