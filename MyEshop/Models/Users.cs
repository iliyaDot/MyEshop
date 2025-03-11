using System.ComponentModel.DataAnnotations;

namespace MyEshop.Models
{
    public class Users
    {
        [Key()]
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password{ get; set; }
        [Required]

        public DateTime RegisterDate { get; set; }

        public bool IsAdmin { get; set; }
    }
}
