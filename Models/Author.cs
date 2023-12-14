using System.ComponentModel.DataAnnotations;

namespace Final_Asm.Models
{
    public class Author
    {
        [Key]public int ID { get; set; }
        [Required] public string Name { get; set; } = null!;
        [Required] public string Description { get; set; } = null!;
    }
}
