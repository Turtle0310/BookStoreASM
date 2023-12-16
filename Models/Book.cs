using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Asm.Models
{
    public class Book
    {
        [Key] public int Id { get; set; }
        [Required] public string NameBook { get; set; } = null!;

        [ForeignKey("Author")]
        [Required] public int ID_Author { get; set; }
        public virtual Author? Author { get; set; }

        [ForeignKey("Category")]
        [Required] public int ID_Category { get; set; }
        public virtual Category? Category { get; set; }

        [ForeignKey("BookOwner")]
        [Required] public int ID_BookOwner { get; set; }
        public virtual BookOwner? BookOwner { get; set; }

        [Required] public string Image { get; set; } = null!;
        [Required] public int Price { get; set; }
        [Required] public int Nums { get; set; }



    }
}
