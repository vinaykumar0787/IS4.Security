using LMS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<LMSEntity> LMSEntities { get; set; }
    }
}