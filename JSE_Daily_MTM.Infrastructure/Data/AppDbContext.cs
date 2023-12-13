using JSE_Daily_MTM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JSE_Daily_MTM.Infrastructure.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<DailyMTM> DailyMTM { get; set; }

    public int SaveChanges()
    {
        return base.SaveChanges();
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=JSEDailyMTM_DB;User Id=sa;Password=R; Trusted_Connection=false;MultipleActiveResultSets=true; Persist Security Info=False;Encrypt=False");
    }
}