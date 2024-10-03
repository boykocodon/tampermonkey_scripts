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

        
       
    }
}
