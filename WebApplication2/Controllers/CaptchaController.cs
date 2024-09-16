using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaptchaController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MyDBContext _dbContext;
        public CaptchaController(ILogger<WeatherForecastController> logger, MyDBContext dBContext)
        {
            _logger = logger;
            _dbContext = dBContext;
        }
        [HttpGet(Name = "SendTask")]
        public async Task<int> SendTask(string profile)
        {
            var existTask = _dbContext.CaptchaTasks.FirstOrDefault(p => p.Profile == profile && !p.IsCompleted);
            if (existTask != null)
            {
                return existTask.Id;
            }
            CaptchaTask captchaTask = new CaptchaTask();
            captchaTask.Profile = profile;
            captchaTask.CreatedDate = DateTime.Now;
            captchaTask.UpdatedDate = DateTime.Now;
            captchaTask.IsSuccess = false;
            captchaTask.IsCompleted = false;
            captchaTask.IsOk = false;
            _dbContext.CaptchaTasks.Add(captchaTask);
            await _dbContext.SaveChangesAsync();
            return captchaTask.Id;
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
            captchaTask.Base64  = base64;
            _dbContext.DropzCaptchas.Add(captchaTask);
            await _dbContext.SaveChangesAsync();
            return captchaTask.Id;
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
