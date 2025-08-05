using DashboardApi.Data;
using DashboardApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        private async Task<DashboardMetric?> GetMetricsByDate(DateTime date)
        {
            var result = await _context.DashboardMetrics
                .FromSqlRaw("EXEC GetMetricsByDate @SearchDate = {0}", date)
                .ToListAsync();

            return result.FirstOrDefault();
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var today = DateTime.Today;
            var yesterday = today.AddDays(-1);

            var latest = await GetMetricsByDate(today);
            var previous = await GetMetricsByDate(yesterday);

            if (latest == null || previous == null)
                return NotFound("Not enough data to calculate differences.");

            decimal CalcPercent(decimal now, decimal prev)
                => prev == 0 ? 0 : Math.Round(((now - prev) / prev) * 100, 2);

            var result = new
            {
                todaysMoney = latest.TodaysMoney,
                todaysUsers = latest.TodaysUsers,
                newClients = latest.NewClients,
                sales = latest.Sales,

                percentChange = new
                {
                    todaysMoney = CalcPercent(latest.TodaysMoney, previous.TodaysMoney),
                    todaysUsers = CalcPercent(latest.TodaysUsers, previous.TodaysUsers),
                    newClients = CalcPercent(latest.NewClients, previous.NewClients),
                    sales = CalcPercent(latest.Sales, previous.Sales)
                }
            };

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMetrics()
        {
            var allMetrics = await _context.DashboardMetrics.ToListAsync();
            return Ok(allMetrics);
        }
        
        
        [HttpPost]
        public async Task<ActionResult<DashboardMetric>> Add(DashboardMetric metric)
        {
            metric.Date = DateTime.Today;
            _context.DashboardMetrics.Add(metric);
            await _context.SaveChangesAsync();
            return Ok(metric);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DashboardMetric updated)
        {
            var metric = await _context.DashboardMetrics.FindAsync(id);
            if (metric == null)
                return NotFound();

            metric.TodaysMoney = updated.TodaysMoney;
            metric.TodaysUsers = updated.TodaysUsers;
            metric.NewClients = updated.NewClients;
            metric.Sales = updated.Sales;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var metric = await _context.DashboardMetrics.FindAsync(id);
            if (metric == null)
                return NotFound();

            _context.DashboardMetrics.Remove(metric);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
