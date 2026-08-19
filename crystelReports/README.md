# Custom Report Engine

A custom HTML report engine in C# (.NET 8) that renders reports from JSON templates + data
sources, intended to replace Crystal Reports. Built per [report-engine-instructions.md](report-engine-instructions.md).

## Solution layout

| Project | TFM | Purpose |
|---|---|---|
| `Core` (`ReportEngine.Core`) | net8.0 | Models, rendering engine, field/expression resolvers |
| `Output` (`ReportEngine.Output`) | net8.0 | `HtmlWriter` — wraps sections in a full HTML doc; writes to string/file/stream |
| `Migrator` (`RptMigrator`) | net8.0-windows | CLI that extracts `.rpt` layouts to JSON (Crystal SDK, gated — see below) |
| `Demo` (`ReportEngine.Demo`) | net8.0 | Console app: template + `DataTable` → `patient-report.html` |
| `Tests` (`ReportEngine.Tests`) | net8.0 | xUnit tests for `FieldResolver`, `ExpressionEvaluator`, `SectionRenderer` |

`Templates/PatientReport.json` is a sample template demonstrating header / pageHeader / detail /
footer bands, data-bound fields, a `dd/MM/yyyy` format suffix, lines, fonts, and expression tokens.

## Build, test, run

```bash
dotnet build ReportEngine.slnx
dotnet test  Tests/ReportEngine.Tests.csproj
dotnet run   --project Demo/ReportEngine.Demo.csproj
# -> writes patient-report.html next to the Demo executable
```

## Using the engine

```csharp
var engine = new ReportEngine.Core.ReportEngine();
string html = engine.Render("Templates/PatientReport.json", dataTable); // or Render(ReportTemplate, DataTable)
ReportEngine.Output.HtmlWriter.WriteToFile(html, "report.html");
```

Expression tokens in text elements: `{page}`, `{totalPages}`, `{date}`, `{datetime}`, `{reportName}`.
Field sources support an optional format suffix, e.g. `"PatientDOB:dd/MM/yyyy"` or `"Amount:N2"`.

## Migrator / Crystal Reports SDK note

The SAP Crystal Reports SDK (`CrystalDecisions.*`) is **not** available in this environment and ships
only for .NET Framework, so the extraction code in `Migrator/RptExtractor.cs` is **compiled only when the
`CRYSTAL` symbol is defined**. By default the solution builds and runs everywhere; calling the extractor
throws a clear `PlatformNotSupportedException`, and the CLI logs the failure per file without crashing.

To enable real `.rpt` extraction on a machine with the SDK installed:

```bash
# (reference CrystalDecisions.CrystalReports.Engine + CrystalDecisions.Shared first;
#  re-target Migrator to net48 if the installed SDK requires .NET Framework)
dotnet build Migrator/ReportEngine.Migrator.csproj -p:DefineConstants=CRYSTAL
RptMigrator --input ./reports/ --output ./templates/
```

## Notes / deviations from the spec sketch

- The spec listed separate `FieldElement`/`TextElement`/`ImageElement` files, but its own Phase 2 model
  code and the JSON format use a single flat element with a `type` discriminator. Consolidated into one
  `ReportElement` so `System.Text.Json` (de)serialization needs no polymorphic converter.
- `Core` depends on `Output` (the engine uses `HtmlWriter` to wrap the document); `Output` has no
  dependency on `Core`, keeping the cycle-free.
- Out of scope (future phases, per spec): PDF output, charts, sub-reports, grouping/aggregation.
