using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace OnlineEnglishTest.Models
{
    public class Question : BaseEntity
    {
        [StringLength(500)]
        [Required]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(500)]
        public string? Image { get; set; }

        [Column(TypeName = "tinyint")]
        public byte? Level { get; set; }

        [Column(TypeName = "tinyint")]
        public byte? Type { get; set; }




        public Int64 CategoryId { get; set; }


        public virtual Category Category { get; set; }

        public virtual List<Answer> Answers { get; set; }

    }
}
