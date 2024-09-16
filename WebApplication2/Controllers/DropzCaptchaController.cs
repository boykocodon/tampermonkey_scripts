using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DropzCaptchaController: ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MyDBContext _dbContext;
        public DropzCaptchaController(ILogger<WeatherForecastController> logger, MyDBContext dBContext)
        {
            _logger = logger;
            _dbContext = dBContext;
        }
        [HttpGet(Name = "SendDropzCaptcha")]
        public async Task<int> SendDropzCaptcha(string profile, string base64)
        {
            var existTask = _dbContext.DropzCaptchas.FirstOrDefault(p => p.Profile == profile && !p.IsCompleted);
            if (existTask != null)
            {
                return existTask.Id;
            }
            DropzCaptcha captchaTask = new DropzCaptcha();
            captchaTask.Profile = profile;
            captchaTask.CreatedDate = DateTime.Now;
            captchaTask.UpdatedDate = DateTime.Now;
            captchaTask.IsSuccess = false;
            captchaTask.IsCompleted = false;
            captchaTask.Base64 = base64;
            _dbContext.DropzCaptchas.Add(captchaTask);
            await _dbContext.SaveChangesAsync();
            return captchaTask.Id;
        }
    }
}
