using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTables()
        {
            var projects = new[]
            {
                new { company = "Material UI", budget = "$14,000", completion = 60 },
                new { company = "Progress Track", budget = "$3,000", completion = 10 },
                new { company = "Fix Errors", budget = "Not set", completion = 100 },
                new { company = "Mobile App", budget = "$20,500", completion = 100 },
                new { company = "Pricing Page", budget = "$500", completion = 25 }
            };

            return Ok(projects);
        }
    }
}
