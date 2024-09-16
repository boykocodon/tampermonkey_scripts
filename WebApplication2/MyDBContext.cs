using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
        : base(options)
        {
        }

        public DbSet<CaptchaTask> CaptchaTasks { get; set; } = null!;

        public DbSet<HCaptchaSolveByCaptchaAI> HCaptchaSolveByCaptchaAIs { get; set; } = null!;
        public DbSet<DropzCaptcha> DropzCaptchas { get; set; } = null!;
    }
}
