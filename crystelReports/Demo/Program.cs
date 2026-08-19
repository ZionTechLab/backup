using System;
using System.Data;
using System.IO;
using ReportEngine.Output;

// Demonstrates the report engine end to end:
//   load a JSON template + a DataTable -> render -> write an HTML file.

// The template is copied next to the executable (see ReportEngine.Demo.csproj),
// with a fallback to the repo's Templates folder when running from source.
string templatePath = Path.Combine(AppContext.BaseDirectory, "Templates", "PatientReport.json");
if (!File.Exists(templatePath))
    templatePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Templates", "PatientReport.json"));

// Build a sample data source (this is what a real query/DataAdapter would return).
var data = new DataTable();
data.Columns.Add("PatientName", typeof(string));
data.Columns.Add("PatientId", typeof(string));
data.Columns.Add("PatientDOB", typeof(DateTime));
data.Columns.Add("Diagnosis", typeof(string));

data.Rows.Add("Alice Fernando", "P-1001", new DateTime(1985, 3, 12), "Hypertension");
data.Rows.Add("Bandula Perera", "P-1002", new DateTime(1990, 11, 2), "Type II Diabetes");
data.Rows.Add("Chathura Silva", "P-1003", new DateTime(1972, 7, 25), "Asthma & <allergies>");

var engine = new ReportEngine.Core.ReportEngine();
string html = engine.Render(templatePath, data);

string outputPath = Path.Combine(AppContext.BaseDirectory, "patient-report.html");
HtmlWriter.WriteToFile(html, outputPath);

Console.WriteLine($"Template : {templatePath}");
Console.WriteLine($"Rows     : {data.Rows.Count}");
Console.WriteLine($"Output   : {outputPath}");
Console.WriteLine($"Bytes    : {html.Length}");
