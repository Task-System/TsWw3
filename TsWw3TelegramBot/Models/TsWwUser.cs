using System.ComponentModel.DataAnnotations;

namespace TsWw3TelegramBot.Models
{
    public class TsWwUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public long TelegramId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Name { get; set; } = null!;
    }
}
