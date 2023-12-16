using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Asm.Models
{
    public class BookOwner
    {
        [ForeignKey("OwnerAcc")]
        public int Id { get; set; }
        public virtual OwnerAcc? OwnerAcc { get; set; }

        [Required] public string NameStore { get; set; } = null!;

    }
}
