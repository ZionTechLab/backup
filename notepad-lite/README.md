# Notepad Lite

A minimal Windows text/markdown editor. Built to replace a "too heavy" .NET notepad clone.

## Status

**Working app: done.** Installer: in progress, not finished.

## Done

- WinForms app (Form + MenuStrip + RichTextBox) at `notepad-lite/`.
- Menus: File (New/Open/Save/Save As/Exit), Edit (Undo/Cut/Copy/Paste), View (Word Wrap, Zoom In/Out/Reset, Markdown Preview), Help (About).
- Opens `.txt` and `.md`. `.md` renders formatted (headings, bold, italic, code, lists) via a hand-written markdown-to-RTF converter (`Markdown/MarkdownToRtf.cs`), with a Preview/Raw toggle.
- Can be launched with a file path argument (needed for file-association double-click support) — verified working.
- Self-contained single-file publish works: `dotnet publish -c Release -r win-x64` → one `notepad-lite.exe` (~116 MB, no .NET install required on target machine). Not trimmed — WinForms doesn't support trimming.
- First build attempt was raw Win32 (P/Invoke, no WinForms) for minimum size. Hit a native crash in the RTF-loading API (`EM_STREAMIN`) that survived every fix tried. Switched to WinForms' `RichTextBox`, which works reliably — traded some size for correctness.

## Not done / in progress

- **Installer (MSI via WiX v5)**: `installer/Product.wxs` is drafted — installs the exe to Program Files, adds a Start Menu shortcut, registers `.txt`/`.md` file associations (proper Windows mechanism, see note below). Was mid-way through fixing WiX schema errors when stopped. Not yet built or tested.
- To resume: `cd installer && wix build Product.wxs -ext WixToolset.UI.wixext -ext WixToolset.Util.wixext -arch x64 -out NotepadLiteSetup.msi`, fix any remaining schema errors, then test-install.

## About "make it default .txt viewer"

Windows has blocked apps from silently forcing themselves as the default file handler since Windows 10 (this is intentional — it's how hijacking malware used to work). The installer instead registers Notepad Lite as a **proper candidate**: it'll show up in right-click → "Open with" and in Settings → Default apps, so the user picks it in one click. The installer also offers to open that Settings page automatically right after install finishes.

There is no supported way to skip that one click.
