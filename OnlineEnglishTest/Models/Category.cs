using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace OnlineEnglishTest.Models
{
    [Table("Category")]
    public class Category : BaseEntity
    {
        [StringLength(500)]
        [Required]
        public string Name { get; set; }


        [StringLength(1000)]
        public string? Description { get; set; }


        [StringLength(500)]
        public string? Icon { get; set; }



        [Column(TypeName = "bigint")]
        public Int64? ParentId { get; set; }


        public virtual List<Question> questions { get; set; }

    }
}
