using System.ComponentModel.DataAnnotations;

namespace Final_Asm.Models
{
    public class Category
    {
        [Key]public int Id { get; set; }
        [Required] public string Name { get; set; } = null!;
    }
}
