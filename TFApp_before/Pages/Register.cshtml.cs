namespace TFApp.Pages;

public class RegisterModel : PageModel
{
    private readonly TFAppContext _context;

    public RegisterModel(TFAppContext context)
    {
        _context = context;
    }

    [BindProperty]
    public User User { get; set; }

    public static readonly string SessionKey = "UserId";

    public async Task<IActionResult> OnGetAsync()
    {
        var session = HttpContext.Session;
        var key = session.GetString(SessionKey);

        if (_context.User != null)
        {
            // 既存ユーザだったらDBから取ってきてその情報をフォームに埋めて表示
            User = await _context.User.FindAsync(key) ?? default!;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = new User
        {
            UserId = Guid.NewGuid().ToString(),
            Name = User.Name,
            City = User.City,
        };

        if (user != null)
        {
            // DBに保存
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            System.IO.File.AppendAllText(@"./log.txt", $"{DateTime.Now:F}: UserIdをDBに保存しました\n");

            // セッションに保存
            HttpContext.Session.SetString(SessionKey, user.UserId);

            System.IO.File.AppendAllText(@"./log.txt", $"{DateTime.Now:F}: UserIdをセッションに保存しました\n");
        }
        else
        {
            System.IO.File.AppendAllText(@"./log.txt", $"{DateTime.Now:F}: DBへの保存が失敗しました\n");
        }

        return RedirectToPage("./Index");
    }
}
