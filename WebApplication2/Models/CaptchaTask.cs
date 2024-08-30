using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class CaptchaTask
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Profile { get; set; }

        public bool IsSuccess { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsOk { get; set; }
    }
}
