using DashboardApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DashboardMetric> DashboardMetrics { get; set; }
    }
}
