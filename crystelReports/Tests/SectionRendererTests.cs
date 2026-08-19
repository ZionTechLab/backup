using System;
using System.Data;
using ReportEngine.Core;
using ReportEngine.Core.Models;
using Xunit;

namespace ReportEngine.Tests;

public class SectionRendererTests
{
    private static SectionRenderer NewRenderer(ExpressionEvaluator? evaluator = null) =>
        new(new FieldResolver(), evaluator ?? new ExpressionEvaluator());

    private static DataRow MakeRow(string name)
    {
        var table = new DataTable();
        table.Columns.Add("PatientName", typeof(string));
        DataRow row = table.NewRow();
        row["PatientName"] = name;
        table.Rows.Add(row);
        return row;
    }

    [Fact]
    public void Renders_Section_Div_With_Height()
    {
        var section = new ReportSection { Height = 42 };
        string html = NewRenderer().Render(section);

        Assert.Contains("class=\"section\"", html);
        Assert.Contains("height:42px;", html);
        Assert.StartsWith("<div", html);
        Assert.EndsWith("</div>", html);
    }

    [Fact]
    public void Renders_Element_With_Absolute_Position()
    {
        var section = new ReportSection
        {
            Height = 20,
            Elements = { new ReportElement { Type = "text", Value = "Hi", X = 5, Y = 7, Width = 100, Height = 18 } }
        };
        string html = NewRenderer().Render(section);

        Assert.Contains("class=\"element\"", html);
        Assert.Contains("position:absolute;left:5px;top:7px;", html);
        Assert.Contains("width:100px;height:18px;", html);
    }

    [Fact]
    public void Field_Element_Resolves_Value_From_Row()
    {
        var section = new ReportSection
        {
            Height = 20,
            Elements = { new ReportElement { Type = "field", Source = "PatientName", Width = 100, Height = 18 } }
        };
        string html = NewRenderer().Render(section, MakeRow("Alice Fernando"));
        Assert.Contains("Alice Fernando", html);
    }

    [Fact]
    public void Field_Element_Without_Row_Renders_Empty()
    {
        var section = new ReportSection
        {
            Height = 20,
            Elements = { new ReportElement { Type = "field", Source = "PatientName", Width = 100, Height = 18 } }
        };
        string html = NewRenderer().Render(section); // no row
        Assert.Contains("class=\"element\"", html);
        Assert.DoesNotContain("PatientName", html); // source name must not leak into output
    }

    [Fact]
    public void Field_Value_Is_Html_Encoded()
    {
        var section = new ReportSection
        {
            Height = 20,
            Elements = { new ReportElement { Type = "field", Source = "PatientName", Width = 100, Height = 18 } }
        };
        string html = NewRenderer().Render(section, MakeRow("a<b> & \"c\""));

        Assert.Contains("a&lt;b&gt; &amp; &quot;c&quot;", html);
        Assert.DoesNotContain("<b>", html);
    }

    [Fact]
    public void Text_Element_Evaluates_Expression_Tokens()
    {
        var evaluator = new ExpressionEvaluator { CurrentPage = 3, TotalPages = 9 };
        var section = new ReportSection
        {
            Height = 20,
            Elements = { new ReportElement { Type = "text", Value = "Page {page} of {totalPages}", Width = 100, Height = 18 } }
        };
        string html = NewRenderer(evaluator).Render(section);
        Assert.Contains("Page 3 of 9", html);
    }

    [Fact]
    public void Image_Element_Renders_Img_Tag()
    {
        var section = new ReportSection
        {
            Height = 40,
            Elements = { new ReportElement { Type = "image", ImagePath = "logo.png", X = 0, Y = 0, Width = 80, Height = 40 } }
        };
        string html = NewRenderer().Render(section);

        Assert.Contains("<img src=\"logo.png\"", html);
        Assert.Contains("width:80px;height:40px;", html);
    }

    [Fact]
    public void Line_Element_Renders_Top_Border()
    {
        var section = new ReportSection
        {
            Height = 2,
            Elements = { new ReportElement { Type = "line", X = 0, Y = 0, Width = 200, Height = 1 } }
        };
        string html = NewRenderer().Render(section);
        Assert.Contains("border-top:1px solid #000000;", html);
    }

    [Fact]
    public void Applies_Font_Styling()
    {
        var section = new ReportSection
        {
            Height = 20,
            Elements =
            {
                new ReportElement
                {
                    Type = "text", Value = "Bold!", Width = 100, Height = 18,
                    Font = new FontStyle { Name = "Verdana", Size = 14, Bold = true, Italic = true, Color = "#ff0000" }
                }
            }
        };
        string html = NewRenderer().Render(section);

        Assert.Contains("font-family:Verdana;", html);
        Assert.Contains("font-size:14px;", html);
        Assert.Contains("color:#ff0000;", html);
        Assert.Contains("font-weight:bold;", html);
        Assert.Contains("font-style:italic;", html);
    }
}
