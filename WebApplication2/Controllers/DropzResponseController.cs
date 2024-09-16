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
            if (existTask == null)
            {
                return "CAPTCHA_NOT_READY";
            }
            if (existTask.IsSuccess && existTask.IsCompleted)
            {
                if (string.IsNullOrEmpty(existTask.Response))
                {
                    return "CAPTCHA_NOT_READY";
                }
                return existTask.Response;
            }
            return "CAPTCHA_NOT_READY";
        }
    }
}
