using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Asm.Models
{
    public class UploadFile
    {
        [Key]public int ID { get; set; }
        [Required] public string? Name { get; set; }
        [Required][NotMapped] public IFormFile FileName { get; set; } = null!;
    }
}
