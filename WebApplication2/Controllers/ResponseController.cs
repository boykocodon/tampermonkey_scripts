using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResponseController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MyDBContext _dbContext;
        public ResponseController(ILogger<WeatherForecastController> logger, MyDBContext dBContext)
        {
            _logger = logger;
            _dbContext = dBContext;
        }

        [HttpGet(Name = "GetCaptchaResponse")]
        public async Task<string> GetCaptchaResponse(int captchaTask)
        {
            var captchaSolved = _dbContext.HCaptchaSolveByCaptchaAIs.FirstOrDefault(p => p.CaptchaTaskId == captchaTask && !p.IsUse);
            if (captchaSolved != null)
            {
                captchaSolved.IsUse = true;
                await _dbContext.SaveChangesAsync();
                return captchaSolved.Reponse;
            }
            return "CAPTCHA_NOT_READY";
        }
    }
}
