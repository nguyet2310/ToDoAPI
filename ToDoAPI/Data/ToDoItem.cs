using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoAPI.Data
{
    [Table("ToDoAPI")]
    public class ToDoItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "ItemName is required")]
        //[Column(TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        public string? ItemName { get; set; }

        [Required(ErrorMessage = "ItemDescription")]
        //[Column(TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        public string? ItemDescription { get; set; }

        [Required(ErrorMessage = "ItemStatus is required")]
        [Column(TypeName = "bit")]
        public bool ItemStatus { get; set; }

    }
}
