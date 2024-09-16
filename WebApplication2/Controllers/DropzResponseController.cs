using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DropzResponseController: ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MyDBContext _dbContext;
        public DropzResponseController(ILogger<WeatherForecastController> logger, MyDBContext dBContext)
        {
            _logger = logger;
            _dbContext = dBContext;
        }
        [HttpGet(Name = "GetDropzCaptcha")]
        public async Task<string> GetDropzCaptcha(int id)
        {
            var existTask = _dbContext.DropzCaptchas.FirstOrDefault(p => p.Id == id);
            if (existTask != null)
            {
                return string.Empty;
            }
            if (existTask.IsSuccess && existTask.IsCompleted)
            {
                return existTask.Response;
            }
            return string.Empty;
        }
    }
}
