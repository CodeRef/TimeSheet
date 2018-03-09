using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class ShelfBook : BaseEntity
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        public virtual Project Book { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Shelf")]
        public int ShelfId { get; set; }

        public virtual Shelf Shelf { get; set; }
    }
}