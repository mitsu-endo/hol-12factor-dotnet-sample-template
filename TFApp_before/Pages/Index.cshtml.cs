using TFApp_library;

namespace TFApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public string? Message { get; set; }

    public void OnGet()
    {
        Message = new SampleClassInLibrary().Message;
    }
}