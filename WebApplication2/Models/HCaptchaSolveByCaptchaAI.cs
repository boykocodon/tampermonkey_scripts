using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class HCaptchaSolveByCaptchaAI
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? SiteKey { get; set; }
        public string? Url { get; set; }
        public bool IsUse { get; set; }
        [Column(TypeName = "text")]
        public string Reponse { get; set; }
        public int CaptchaTaskId { get; set; }
    }
}
