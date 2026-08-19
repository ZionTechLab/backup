# Custom Report Engine — Coding Agent Instructions

## Objective
Build a custom HTML report engine in C# that:
1. Extracts layout metadata from Crystal Reports `.rpt` files (one-time migration)
2. Saves layout as a JSON template format
3. Renders HTML reports from JSON templates + data sources
4. Replaces Crystal Reports entirely after migration

---

## Project Structure

```
ReportEngine/
├── Migrator/
│   ├── RptExtractor.cs         # Extracts layout from .rpt using Crystal SDK
│   ├── RptExtractorRunner.cs   # CLI entry point for migration tool
├── Core/
│   ├── Models/
│   │   ├── ReportTemplate.cs   # Root template model
│   │   ├── ReportSection.cs    # Header / Detail / Footer section
│   │   ├── ReportElement.cs    # Base element (text, field, image, line)
│   │   ├── FieldElement.cs     # Data-bound field element
│   │   ├── TextElement.cs      # Static text element
│   │   ├── ImageElement.cs     # Image element
│   ├── ReportEngine.cs         # Main engine: loads template + data → HTML
│   ├── SectionRenderer.cs      # Renders a single section to HTML
│   ├── FieldResolver.cs        # Resolves field values from DataRow/object
│   ├── ExpressionEvaluator.cs  # Handles expressions like {page}, {date}
├── Output/
│   ├── HtmlWriter.cs           # Writes final HTML string to file or stream
├── Templates/                  # Saved JSON report templates
├── ReportEngine.sln
```

---

## Phase 1 — RPT Migrator

### RptExtractor.cs

**Purpose:** Use Crystal Reports SDK to read `.rpt` and output a `ReportTemplate` JSON file.

**Requirements:**
- NuGet: `CrystalDecisions.CrystalReports.Engine`, `CrystalDecisions.Shared`
- Load each `.rpt` file
- Iterate `report.ReportDefinition.ReportObjects`
- For each object extract:
  - `Kind` (Field, Text, Picture, Line, Box)
  - `Name`
  - `Left`, `Top`, `Width`, `Height` (in twips — convert to px: divide by 15)
  - `DataSource` (for field objects)
  - `Text` (for text objects)
  - Font: name, size, bold, italic, color
  - Section: ReportHeader, PageHeader, Detail, PageFooter, ReportFooter
- Map section kinds to: `header`, `pageHeader`, `detail`, `pageFooter`, `footer`
- Serialize output to JSON using `System.Text.Json`

**Output format (ReportTemplate JSON):**
```json
{
  "name": "PatientReport",
  "pageWidth": 850,
  "pageHeight": 1100,
  "sections": {
    "header": {
      "height": 60,
      "elements": [
        {
          "type": "text",
          "value": "Sun Medical Hospital",
          "x": 10, "y": 10,
          "width": 300, "height": 20,
          "font": { "name": "Arial", "size": 14, "bold": true, "color": "#000000" }
        }
      ]
    },
    "detail": {
      "height": 20,
      "elements": [
        {
          "type": "field",
          "source": "PatientName",
          "x": 10, "y": 0,
          "width": 200, "height": 18,
          "font": { "name": "Arial", "size": 10, "bold": false, "color": "#000000" }
        }
      ]
    },
    "footer": {
      "height": 30,
      "elements": [
        {
          "type": "text",
          "value": "Page {page} of {totalPages}",
          "x": 10, "y": 5,
          "width": 200, "height": 18
        }
      ]
    }
  }
}
```

---

## Phase 2 — Core Models

### ReportTemplate.cs
```csharp
public class ReportTemplate
{
    public string Name { get; set; }
    public int PageWidth { get; set; }
    public int PageHeight { get; set; }
    public Dictionary<string, ReportSection> Sections { get; set; }
}
```

### ReportSection.cs
```csharp
public class ReportSection
{
    public int Height { get; set; }
    public List<ReportElement> Elements { get; set; }
}
```

### ReportElement.cs
```csharp
public class ReportElement
{
    public string Type { get; set; }  // "text", "field", "image", "line"
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public FontStyle Font { get; set; }
    public string Value { get; set; }   // for type=text
    public string Source { get; set; }  // for type=field (maps to DataRow column)
    public string ImagePath { get; set; } // for type=image
}

public class FontStyle
{
    public string Name { get; set; } = "Arial";
    public int Size { get; set; } = 10;
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public string Color { get; set; } = "#000000";
}
```

---

## Phase 3 — Report Engine

### ReportEngine.cs

**Purpose:** Load a JSON template and a data source, produce HTML output.

**Method signature:**
```csharp
public string Render(string templatePath, DataTable data)
public string Render(ReportTemplate template, DataTable data)
```

**Rendering logic:**
1. Load and deserialize JSON template
2. Render `header` section once (no data binding)
3. Render `pageHeader` section once
4. For each `DataRow` in data: render `detail` section with row values
5. Render `pageFooter` section once
6. Render `footer` section once
7. Return full HTML string

### SectionRenderer.cs

**Purpose:** Convert a `ReportSection` + optional `DataRow` to an HTML `<div>`.

**Requirements:**
- Section renders as a `<div>` with `position: relative; height: {section.Height}px`
- Each element renders as a `<div>` with `position: absolute; left: {x}px; top: {y}px; width: {w}px; height: {h}px`
- Apply font styles inline
- For `type=field`: resolve value via `FieldResolver`
- For `type=text`: render `Value`, process expressions via `ExpressionEvaluator`
- For `type=image`: render `<img src="{ImagePath}">`

### FieldResolver.cs

**Purpose:** Given a field `Source` name and a `DataRow`, return the string value.

**Requirements:**
- Match `Source` to `DataRow` column name (case-insensitive)
- Handle null values — return empty string
- Support format strings (e.g., `PatientDOB:dd/MM/yyyy`)

### ExpressionEvaluator.cs

**Purpose:** Replace tokens in text values.

**Supported tokens:**
- `{page}` — current page number
- `{totalPages}` — total page count
- `{date}` — today's date (dd/MM/yyyy)
- `{datetime}` — current datetime
- `{reportName}` — template name

---

## Phase 4 — HTML Output

### HtmlWriter.cs

**Requirements:**
- Wrap rendered sections in a full HTML document
- Include base CSS:
  ```css
  body { margin: 0; font-family: Arial, sans-serif; }
  .report-page { width: {pageWidth}px; margin: auto; }
  .section { position: relative; width: 100%; }
  .element { position: absolute; overflow: hidden; white-space: nowrap; }
  ```
- Support writing to: string, file path, or `Stream`
- Method: `void WriteToFile(string html, string outputPath)`

---

## Phase 5 — CLI Migration Runner

### RptExtractorRunner.cs

**Purpose:** Command-line tool to batch convert `.rpt` files to JSON templates.

**Usage:**
```
RptMigrator.exe --input ./reports/ --output ./templates/
```

**Requirements:**
- Accept `--input` folder (scans all `.rpt` files recursively)
- Accept `--output` folder for JSON files
- Log success/failure per file
- Do not crash on one failure — continue to next file

---

## Technical Constraints

- Target framework: **.NET 6** or later
- JSON: use `System.Text.Json` (not Newtonsoft)
- No third-party rendering libraries
- Crystal Reports SDK used **only** in the Migrator project — not in Core or Output
- All positions stored in **pixels** (convert from twips during extraction: px = twips / 15)
- HTML output must render correctly in Chrome and Edge

---

## Deliverables

1. Working solution with all projects above
2. Sample JSON template (manually created or extracted)
3. Console app that renders a sample `DataTable` to HTML using a JSON template
4. Unit tests for: `FieldResolver`, `ExpressionEvaluator`, `SectionRenderer`

---

## Out of Scope

- PDF output (future phase)
- Charts/graphs
- Sub-reports
- Grouping/aggregation (implement as future extension)
