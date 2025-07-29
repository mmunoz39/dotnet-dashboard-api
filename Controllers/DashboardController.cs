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
        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var latest = await _context.DashboardMetrics
                .OrderByDescending(m => m.Date)
                .FirstOrDefaultAsync();

            if (latest == null)
                return NotFound("No data found.");

            return Ok(latest);
        }
       
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMetrics()
        {
            var allMetrics = await _context.DashboardMetrics.ToListAsync();
            return Ok(allMetrics);
        }
    }
}
