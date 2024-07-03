namespace TFApp.Pages;

public class WeatherModel : PageModel
{
    private readonly TFAppContext _context;

    public WeatherModel(TFAppContext context)
    {
        _context = context;
    }

    public string? UserId { get; private set; }

    public Weather? Weather { get; set; }

    public async Task OnGetAsync()
    {
        // var session = HttpContext.Session;
        // var key = session.GetString(RegisterModel.SessionKey);
        // UserId = key;

        // if (_context.User != null)
        // {
        //     // セッションと同じユーザーをDBから取得
        //     var user = await _context.User.FindAsync(key);

        //     // weather-apiをたたく
        //     if (user != null)
        //     {
        //         using (var client = new HttpClient())
        //         {
        //             // ヘッダーにApiKeyを付与
        //             client.DefaultRequestHeaders.Add("x-api-key", Environment.GetEnvironmentVariable("ApiKey"));

        //             var response = await client.GetAsync($"https://{your-functions-app}/api/weather/{user.City}");

        //             if (response.IsSuccessStatusCode)
        //             {
        //                 var responseBody = await response.Content.ReadAsStringAsync();

        //                 Weather = JsonSerializer.Deserialize<Weather>(responseBody);

        //                 System.IO.File.AppendAllText(@"./log.txt", $"{DateTime.Now:F}: weather-apiのコールに成功しました\n");
        //             }
        //         }
        //     }
        //     else
        //     {
        //         Weather = null;

        //         System.IO.File.AppendAllText(@"./log.txt", $"{DateTime.Now:F}: ユーザーの登録処理が失敗しました\n");
        //     }
        // }
    }
}
