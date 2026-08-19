using NotepadLite.Markdown;
using System.Text.RegularExpressions;

namespace NotepadLite;

internal sealed class MainForm : Form
{
    private readonly RichTextBox _editor;
    private readonly ToolStripMenuItem _wordWrapItem;
    private readonly ToolStripMenuItem _previewItem;
    private readonly StatusStrip _statusStrip;
    private readonly ToolStripStatusLabel _wordCountLabel;

    private string? _currentPath;
    private bool _isMarkdown;
    private bool _previewMode;
    private string _rawText = string.Empty;

    public MainForm(string? initialFile = null)
    {
        Text = "Untitled - Notepad Lite";
        Width = 900;
        Height = 650;
        StartPosition = FormStartPosition.CenterScreen;

        _editor = new RichTextBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 11f),
            AcceptsTab = true,
            WordWrap = true,
            BorderStyle = BorderStyle.Fixed3D
        };
        _editor.TextChanged += (_, _) => UpdateWordCount();

        var menu = new MenuStrip();

        var fileMenu = new ToolStripMenuItem("&File");
        fileMenu.DropDownItems.Add(MenuItem("&New", Keys.Control | Keys.N, (_, _) => NewFile()));
        fileMenu.DropDownItems.Add(MenuItem("&Open...", Keys.Control | Keys.O, (_, _) => OpenFile()));
        fileMenu.DropDownItems.Add(MenuItem("&Save", Keys.Control | Keys.S, (_, _) => SaveFile()));
        fileMenu.DropDownItems.Add(MenuItem("Save &As...", Keys.None, (_, _) => SaveFileAs()));
        fileMenu.DropDownItems.Add(new ToolStripSeparator());
        fileMenu.DropDownItems.Add(MenuItem("E&xit", Keys.None, (_, _) => Close()));

        var editMenu = new ToolStripMenuItem("&Edit");
        editMenu.DropDownItems.Add(MenuItem("&Undo", Keys.Control | Keys.Z, (_, _) => _editor.Undo()));
        editMenu.DropDownItems.Add(new ToolStripSeparator());
        editMenu.DropDownItems.Add(MenuItem("Cu&t", Keys.Control | Keys.X, (_, _) => _editor.Cut()));
        editMenu.DropDownItems.Add(MenuItem("&Copy", Keys.Control | Keys.C, (_, _) => _editor.Copy()));
        editMenu.DropDownItems.Add(MenuItem("&Paste", Keys.Control | Keys.V, (_, _) => _editor.Paste()));

        var viewMenu = new ToolStripMenuItem("&View");
        _wordWrapItem = new ToolStripMenuItem("&Word Wrap") { Checked = true };
        _wordWrapItem.Click += (_, _) => ToggleWordWrap();
        viewMenu.DropDownItems.Add(_wordWrapItem);
        viewMenu.DropDownItems.Add(new ToolStripSeparator());
        viewMenu.DropDownItems.Add(MenuItem("Zoom &In", Keys.Control | Keys.Oemplus, (_, _) => SetZoom(_editor.ZoomFactor + 0.1f)));
        viewMenu.DropDownItems.Add(MenuItem("Zoom &Out", Keys.Control | Keys.OemMinus, (_, _) => SetZoom(_editor.ZoomFactor - 0.1f)));
        viewMenu.DropDownItems.Add(MenuItem("&Reset Zoom", Keys.None, (_, _) => SetZoom(1.0f)));
        viewMenu.DropDownItems.Add(new ToolStripSeparator());
        _previewItem = new ToolStripMenuItem("Markdown &Preview") { Enabled = false, ShortcutKeys = Keys.Control | Keys.M };
        _previewItem.Click += (_, _) => TogglePreview();
        viewMenu.DropDownItems.Add(_previewItem);

        var helpMenu = new ToolStripMenuItem("&Help");
        helpMenu.DropDownItems.Add("&About", null, (_, _) =>
            MessageBox.Show(this, "Notepad Lite\nA minimal text/markdown editor.", "About",
                MessageBoxButtons.OK, MessageBoxIcon.Information));

        menu.Items.Add(fileMenu);
        menu.Items.Add(editMenu);
        menu.Items.Add(viewMenu);
        menu.Items.Add(helpMenu);

        MainMenuStrip = menu;
        Controls.Add(_editor);
        // Status strip with word count
        _statusStrip = new StatusStrip { Dock = DockStyle.Bottom };
        _wordCountLabel = new ToolStripStatusLabel("Words: 0");
        _statusStrip.Items.Add(_wordCountLabel);
        Controls.Add(_statusStrip);
        Controls.Add(menu);

        if (!string.IsNullOrEmpty(initialFile))
        {
            LoadFile(initialFile);
        }
    }

    private static ToolStripMenuItem MenuItem(string text, Keys shortcut, EventHandler onClick)
    {
        var item = new ToolStripMenuItem(text);
        if (shortcut != Keys.None) item.ShortcutKeys = shortcut;
        item.Click += onClick;
        return item;
    }

    private void NewFile()
    {
        _currentPath = null;
        _isMarkdown = false;
        _previewMode = false;
        _rawText = string.Empty;

        _editor.ReadOnly = false;
        _editor.Text = string.Empty;

        _previewItem.Enabled = false;
        _previewItem.Checked = false;

        UpdateTitle();
    }

    private void OpenFile()
    {
        using var dialog = new OpenFileDialog
        {
            Filter = "Text Files (*.txt)|*.txt|Markdown Files (*.md)|*.md|All Files (*.*)|*.*",
            Title = "Open"
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;

        LoadFile(dialog.FileName);
    }

    private void LoadFile(string path)
    {
        string content;
        try
        {
            content = File.ReadAllText(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Could not open file:\n{ex.Message}", "Notepad Lite", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _currentPath = path;
        _isMarkdown = _currentPath.EndsWith(".md", StringComparison.OrdinalIgnoreCase);
        _rawText = content;

        _previewItem.Enabled = _isMarkdown;

        if (_isMarkdown)
        {
            _previewMode = true;
            _editor.Rtf = MarkdownToRtf.Convert(_rawText);
            _editor.ReadOnly = true;
        }
        else
        {
            _previewMode = false;
            _editor.ReadOnly = false;
            _editor.Text = content;
        }

        UpdateWordCount();

        _previewItem.Checked = _previewMode;
        UpdateTitle();
    }

    private void SaveFile()
    {
        if (_currentPath is null)
        {
            SaveFileAs();
            return;
        }
        WriteCurrentContent(_currentPath);
    }

    private void SaveFileAs()
    {
        using var dialog = new SaveFileDialog
        {
            Filter = "Text Files (*.txt)|*.txt|Markdown Files (*.md)|*.md|All Files (*.*)|*.*",
            DefaultExt = _isMarkdown ? "md" : "txt",
            Title = "Save As"
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;

        _currentPath = dialog.FileName;
        _isMarkdown = _currentPath.EndsWith(".md", StringComparison.OrdinalIgnoreCase);
        _previewItem.Enabled = _isMarkdown;

        WriteCurrentContent(_currentPath);
        UpdateTitle();
    }

    private void WriteCurrentContent(string path)
    {
        string content;
        if (_isMarkdown && !_previewMode)
        {
            content = _editor.Text;
            _rawText = content;
        }
        else if (_isMarkdown)
        {
            content = _rawText;
        }
        else
        {
            content = _editor.Text;
        }

        try
        {
            File.WriteAllText(path, content);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Could not save file:\n{ex.Message}", "Notepad Lite", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ToggleWordWrap()
    {
        _editor.WordWrap = !_editor.WordWrap;
        _wordWrapItem.Checked = _editor.WordWrap;
    }

    private void SetZoom(float factor)
    {
        _editor.ZoomFactor = Math.Clamp(factor, 0.25f, 5.0f);
    }

    private void TogglePreview()
    {
        if (!_isMarkdown) return;

        if (_previewMode)
        {
            _editor.ReadOnly = false;
            _editor.Text = _rawText;
            _previewMode = false;
        }
        else
        {
            _rawText = _editor.Text;
            _editor.Rtf = MarkdownToRtf.Convert(_rawText);
            _editor.ReadOnly = true;
            _previewMode = true;
        }

        _previewItem.Checked = _previewMode;
        UpdateTitle();
        UpdateWordCount();
    }

    private void UpdateWordCount()
    {
        string text;
        if (_isMarkdown && _previewMode)
        {
            // when previewing, use the raw markdown source for count
            text = _rawText ?? string.Empty;
            text = StripMarkdown(text);
        }
        else
        {
            text = _editor.Text ?? string.Empty;
            if (_isMarkdown) text = StripMarkdown(text);
        }

        // Simple word count: count runs of non-whitespace characters
        int count = Regex.Matches(text, @"\S+").Count;
        _wordCountLabel.Text = $"Words: {count}";
    }

    private static string StripMarkdown(string md)
    {
        if (string.IsNullOrWhiteSpace(md)) return string.Empty;

        // Remove fenced code blocks
        md = Regex.Replace(md, @"```[\s\S]*?```", "", RegexOptions.Singleline);
        // Remove inline code
        md = Regex.Replace(md, @"`[^`]*`", "");
        // Remove HTML tags
        md = Regex.Replace(md, @"<[^>]+>", "");
        // Convert images ![alt](url) -> alt
            md = Regex.Replace(md, @"!\[([^\]]*)\]\([^\)]*\)", "$1");
        // Convert links [text](url) -> text
            md = Regex.Replace(md, @"\[(.*?)\]\([^\)]*\)", "$1");
        // Remove heading markers
        md = Regex.Replace(md, @"^#{1,6}\s*", "", RegexOptions.Multiline);
        // Remove emphasis markers
        md = md.Replace("**", "").Replace("__", "").Replace("*", "").Replace("_", "").Replace("~~", "");
        // Remove table pipes
        md = md.Replace("|", " ");
        // Remove blockquote and list markers at line starts
        md = Regex.Replace(md, @"^[>\-\+\*]\s+", "", RegexOptions.Multiline);
        // Collapse whitespace
        md = Regex.Replace(md, @"\s+", " ").Trim();
        return md;
    }

    private void UpdateTitle()
    {
        string name = _currentPath is null ? "Untitled" : Path.GetFileName(_currentPath);
        string mode = _isMarkdown ? (_previewMode ? " [Preview]" : " [Raw]") : "";
        Text = $"{name}{mode} - Notepad Lite";
    }
}
