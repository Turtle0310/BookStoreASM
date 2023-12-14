using System.ComponentModel.DataAnnotations;

namespace Final_Asm.Models
{
    public class Customer
    {
        [Key] public int Id { get; set; }
        [Required] public string Account { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
    }
}
