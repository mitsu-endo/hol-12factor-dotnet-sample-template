namespace TFApp.Data;

public class TFAppContext : DbContext
{
    public TFAppContext(DbContextOptions<TFAppContext> options)
        : base(options)
    {
    }

    public DbSet<TFApp.Models.User> User { get; set; } = default!;
}
