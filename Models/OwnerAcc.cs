using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Asm.Models
{
    public class OwnerAcc
    {
        [Key] public int Id { get; set; }
        [Required] public string Account { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;


    }
}
