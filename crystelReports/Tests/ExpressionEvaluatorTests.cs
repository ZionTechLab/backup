using System;
using ReportEngine.Core;
using Xunit;

namespace ReportEngine.Tests;

public class ExpressionEvaluatorTests
{
    [Fact]
    public void Replaces_Page_And_TotalPages()
    {
        var evaluator = new ExpressionEvaluator { CurrentPage = 2, TotalPages = 5 };
        Assert.Equal("Page 2 of 5", evaluator.Evaluate("Page {page} of {totalPages}"));
    }

    [Fact]
    public void Replaces_ReportName()
    {
        var evaluator = new ExpressionEvaluator { ReportName = "PatientReport" };
        Assert.Equal("Report: PatientReport", evaluator.Evaluate("Report: {reportName}"));
    }

    [Fact]
    public void Replaces_Date_Using_Injected_Clock()
    {
        var evaluator = new ExpressionEvaluator { Now = () => new DateTime(2026, 5, 31, 14, 5, 9) };
        Assert.Equal("31/05/2026", evaluator.Evaluate("{date}"));
    }

    [Fact]
    public void Replaces_DateTime_Using_Injected_Clock()
    {
        var evaluator = new ExpressionEvaluator { Now = () => new DateTime(2026, 5, 31, 14, 5, 9) };
        Assert.Equal("31/05/2026 14:05:09", evaluator.Evaluate("{datetime}"));
    }

    [Fact]
    public void Replaces_Multiple_Tokens_In_One_String()
    {
        var evaluator = new ExpressionEvaluator
        {
            CurrentPage = 1,
            TotalPages = 3,
            ReportName = "R",
            Now = () => new DateTime(2026, 1, 2)
        };
        Assert.Equal("R 02/01/2026 1/3", evaluator.Evaluate("{reportName} {date} {page}/{totalPages}"));
    }

    [Fact]
    public void Leaves_Unknown_Tokens_Untouched()
    {
        var evaluator = new ExpressionEvaluator();
        Assert.Equal("Hello {name}", evaluator.Evaluate("Hello {name}"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Null_Or_Empty_Returns_Empty(string? input)
    {
        Assert.Equal("", new ExpressionEvaluator().Evaluate(input));
    }
}
