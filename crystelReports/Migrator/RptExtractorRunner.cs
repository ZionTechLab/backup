using System;
using System.IO;

namespace ReportEngine.Migrator;

/// <summary>
/// CLI entry point for batch-converting Crystal <c>.rpt</c> files to JSON templates.
///
/// Usage:  RptMigrator --input ./reports/ --output ./templates/
/// </summary>
internal static class RptExtractorRunner
{
    private static int Main(string[] args)
    {
        string? input = GetOption(args, "--input");
        string? output = GetOption(args, "--output");

        if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(output))
        {
            Console.Error.WriteLine("Usage: RptMigrator --input <folder> --output <folder>");
            Console.Error.WriteLine("  Scans --input recursively for *.rpt files and writes a .json template per file to --output.");
            return 1;
        }

        if (!Directory.Exists(input))
        {
            Console.Error.WriteLine($"Input folder not found: {input}");
            return 1;
        }

        Directory.CreateDirectory(output);

        string[] files = Directory.GetFiles(input, "*.rpt", SearchOption.AllDirectories);
        Console.WriteLine($"Found {files.Length} .rpt file(s) under '{input}'.");

        var extractor = new RptExtractor();
        int succeeded = 0, failed = 0;

        foreach (string file in files)
        {
            string outputPath = Path.Combine(output, Path.GetFileNameWithoutExtension(file) + ".json");
            try
            {
                extractor.ExtractToFile(file, outputPath);
                Console.WriteLine($"[ OK ] {file} -> {outputPath}");
                succeeded++;
            }
            catch (Exception ex)
            {
                // Per spec: never crash on a single file; log and continue.
                Console.Error.WriteLine($"[FAIL] {file}: {ex.Message}");
                failed++;
            }
        }

        Console.WriteLine($"Done. Succeeded: {succeeded}, Failed: {failed}.");
        return failed == 0 ? 0 : 2;
    }

    /// <summary>Returns the value following <paramref name="name"/> in <paramref name="args"/>, or null.</summary>
    private static string? GetOption(string[] args, string name)
    {
        for (int i = 0; i < args.Length - 1; i++)
        {
            if (string.Equals(args[i], name, StringComparison.OrdinalIgnoreCase))
                return args[i + 1];
        }
        return null;
    }
}
