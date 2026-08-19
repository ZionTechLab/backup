using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FileCopyApp.Pages;

public class IndexModel : PageModel
{
    private readonly IConfiguration _config;
    private readonly ILogger<IndexModel> _logger;

    [TempData]
    public string? StatusMessage { get; set; }

    [TempData]
    public bool IsSuccess { get; set; }

    public IndexModel(IConfiguration config, ILogger<IndexModel> logger)
    {
        _config = config;
        _logger = logger;
    }

    public void OnGet() { }

    public IActionResult OnPostCopyOldReport()
    {
        CopyFile("OldReport");
        return RedirectToPage();
    }

    public IActionResult OnPostCopyNewReport()
    {
        CopyFile("NewReport");
        return RedirectToPage();
    }

    private void CopyFile(string reportKey)
    {
        var source = _config[$"FileCopy:{reportKey}:SourcePath"];
        var destination = _config[$"FileCopy:{reportKey}:DestinationPath"];

        if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination))
        {
            IsSuccess = false;
            StatusMessage = $"Configuration missing for {reportKey}. Check appsettings.json.";
            return;
        }

        try
        {
            if (!System.IO.File.Exists(source))
            {
                IsSuccess = false;
                StatusMessage = $"Source file not found: {source}";
                return;
            }

            var destDir = Path.GetDirectoryName(destination);
            if (!string.IsNullOrEmpty(destDir))
                Directory.CreateDirectory(destDir);

            System.IO.File.Copy(source, destination, overwrite: true);
            _logger.LogInformation("Copied {Source} to {Destination}", source, destination);

            IsSuccess = true;
            StatusMessage = $"File copied successfully to {destination}";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to copy {ReportKey}", reportKey);
            IsSuccess = false;
            StatusMessage = $"Error copying file: {ex.Message}";
        }
    }
}
