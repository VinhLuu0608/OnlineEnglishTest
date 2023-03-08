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
        [Required]
        public string Description { get; set; }

        [StringLength(500)]
        [Required]
        public string Image { get; set; }

        [Column(TypeName = "tinyint")]
        [Required]
        public byte Level { get; set; }

        [Column(TypeName = "tinyint")]
        [Required]
        public byte Type { get; set; }


        [Column(TypeName = "tinyint")]
        public new byte Status { get; set; }


        public Int64 CategoryId { get; set; }


        public virtual Category Category { get; set; }

        public virtual List<Answer> Answers { get; set; }

    }
}
