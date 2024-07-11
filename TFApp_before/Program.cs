var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddDbContext<TFAppContext>(options =>
//    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("TFAppContext")));
builder.Services.AddDbContext<TFAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TFAppContext")));

// builder.Services.AddDistributedMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    options.InstanceName = builder.Environment.EnvironmentName.ToLower();
});

// セッションの設定
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//1.Program.cs に名前付き HTTP クライアントを登録する（セッションの下）
builder.Services.AddHttpClient("weather", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://fnappc3uxrtcknrrgm.azurewebsites.net/");
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
