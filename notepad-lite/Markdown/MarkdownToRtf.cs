using System.Text;
using System.Linq;

namespace NotepadLite.Markdown;

internal static class MarkdownToRtf
{
    public static string Convert(string markdown)
    {
        var sb = new StringBuilder();
        sb.Append(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033");
        sb.Append(@"{\fonttbl{\f0\fswiss Segoe UI;}{\f1\fmodern Consolas;}}");
        sb.Append(@"\viewkind4\uc1\pard\f0\fs22 ");

        string[] lines = markdown.Replace("\r\n", "\n").Split('\n');
        bool firstLine = true;

        for (int idx = 0; idx < lines.Length; idx++)
        {
            string line = lines[idx];
            if (!firstLine) sb.Append(@"\par ");
            firstLine = false;

            if (line.Length == 0) continue;

            int headingLevel = 0;
            while (headingLevel < line.Length && headingLevel < 3 && line[headingLevel] == '#')
                headingLevel++;

            if (headingLevel > 0 && headingLevel < line.Length && line[headingLevel] == ' ')
            {
                int fontSize = headingLevel switch { 1 => 40, 2 => 32, _ => 26 };
                sb.Append($@"\b\fs{fontSize} ");
                AppendInline(sb, line[(headingLevel + 1)..]);
                sb.Append(@"\b0\fs22 ");
                continue;
            }

            if (line.StartsWith("- ") || line.StartsWith("* ") || line.StartsWith("+ "))
            {
                sb.Append(@"\bullet  ");
                AppendInline(sb, line[2..]);
                continue;
            }

            // Minimal, low-weight table support: detect header + separator line and convert
            // to simple tab-delimited rows in RTF. This avoids adding heavy table layout code.
            if (line.Contains("|") && idx + 1 < lines.Length)
            {
                string next = lines[idx + 1] ?? string.Empty;
                string sep = new string(next.Where(c => !char.IsWhiteSpace(c)).ToArray());
                bool hasDash = sep.Contains('-');
                bool isSep = hasDash && sep.Length > 0 && sep.All(c => c == '|' || c == '-' || c == ':');
                if (isSep)
                {
                    // Header row
                    var headerCells = line.Split('|').Select(s => s.Trim()).ToArray();
                    int start = 0, end = headerCells.Length - 1;
                    if (headerCells.Length > 0 && headerCells[0] == string.Empty) start = 1;
                    if (end >= start && headerCells[end] == string.Empty) end--;

                    // Render as a lightweight RTF table with borders.
                    int colCount = end - start + 1;
                    int cellWidth = 4500; // twips per column (simple fixed width)

                    // Build header row with borders
                    sb.Append(@"\trowd\trgaph108 ");
                    int acc = 0;
                    for (int ci = 0; ci < colCount; ci++)
                    {
                        acc += cellWidth;
                        sb.Append(@"\clbrdrt\brdrs\brdrw10\clbrdrl\brdrs\brdrw10\clbrdrb\brdrs\brdrw10\clbrdrr\brdrs\brdrw10 ");
                        sb.Append($@"\cellx{acc} ");
                    }

                    // Header cell contents (bold)
                    for (int ci = start; ci <= end; ci++)
                    {
                        sb.Append(@"\intbl \b ");
                        AppendInline(sb, headerCells[ci]);
                        sb.Append(@"\b0 \cell ");
                    }
                    sb.Append(@"\row ");

                    // Body rows
                    int r = idx + 2;
                    for (; r < lines.Length; r++)
                    {
                        if (string.IsNullOrWhiteSpace(lines[r])) break;
                        if (!lines[r].Contains("|")) break;
                        var cells = lines[r].Split('|').Select(s => s.Trim()).ToArray();
                        int s2 = 0, e2 = cells.Length - 1;
                        if (cells.Length > 0 && cells[0] == string.Empty) s2 = 1;
                        if (e2 >= s2 && cells[e2] == string.Empty) e2--;

                        // Start row
                        sb.Append(@"\trowd\trgaph108 ");
                        acc = 0;
                        for (int ci = 0; ci < colCount; ci++)
                        {
                            acc += cellWidth;
                            sb.Append(@"\clbrdrt\brdrs\brdrw10\clbrdrl\brdrs\brdrw10\clbrdrb\brdrs\brdrw10\clbrdrr\brdrs\brdrw10 ");
                            sb.Append($@"\cellx{acc} ");
                        }

                        for (int ci = s2; ci <= e2; ci++)
                        {
                            sb.Append(@"\intbl ");
                            AppendInline(sb, cells[ci]);
                            sb.Append(@" \cell ");
                        }
                        // Fill missing cells if row has fewer columns
                        int filled = (e2 - s2 + 1);
                        for (int f = 0; f < colCount - filled; f++) sb.Append(@"\intbl \cell ");

                        sb.Append(@"\row ");
                    }

                    idx = r - 1;
                    continue;
                }
            }

            AppendInline(sb, line);
        }

        sb.Append('}');
        return sb.ToString();
    }

    private static void AppendInline(StringBuilder sb, string text)
    {
        int i = 0;
        bool bold = false, italic = false, code = false;

        while (i < text.Length)
        {
            if (i + 1 < text.Length && text[i] == '*' && text[i + 1] == '*')
            {
                sb.Append(bold ? @"\b0 " : @"\b ");
                bold = !bold;
                i += 2;
                continue;
            }
            if (text[i] == '`')
            {
                sb.Append(code ? @"\f0 " : @"\f1 ");
                code = !code;
                i += 1;
                continue;
            }
            if (text[i] == '*' || text[i] == '_')
            {
                sb.Append(italic ? @"\i0 " : @"\i ");
                italic = !italic;
                i += 1;
                continue;
            }
            AppendEscapedChar(sb, text[i]);
            i++;
        }

        if (bold) sb.Append(@"\b0 ");
        if (italic) sb.Append(@"\i0 ");
        if (code) sb.Append(@"\f0 ");
    }

    private static void AppendEscapedChar(StringBuilder sb, char c)
    {
        switch (c)
        {
            case '\\': sb.Append(@"\\"); break;
            case '{': sb.Append(@"\{"); break;
            case '}': sb.Append(@"\}"); break;
            default:
                if (c > 127)
                    sb.Append($@"\u{(short)c}?");
                else
                    sb.Append(c);
                break;
        }
    }
}
