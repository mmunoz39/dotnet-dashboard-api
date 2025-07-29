using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProfile()
        {
            var user = new
            {
                name = "Marcelo Muñoz",
                email = "marcelo@example.com",
                role = "Full Stack Developer",
                location = "Saskatoon, SK"
            };

            return Ok(user);
        }
    }
}
