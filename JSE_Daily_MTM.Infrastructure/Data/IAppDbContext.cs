using Microsoft.EntityFrameworkCore;
using JSE_Daily_MTM.Domain.Entities;

namespace JSE_Daily_MTM.Infrastructure.Data;

public interface IAppDbContext
{
    DbSet<DailyMTM> DailyMTM { get; set; }
    int SaveChanges();
}