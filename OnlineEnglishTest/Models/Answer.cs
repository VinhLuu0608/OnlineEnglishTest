using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace OnlineEnglishTest.Models
{
    public class Answer : BaseEntity
    {
        [StringLength(500)]
        [Required]
        public string Name { get; set; }


        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(500)]
        public string? Hint { get; set; }


        [StringLength(500)]
        public string? Image { get; set; }


        [StringLength(500)]
        public string? IsCorrect { get; set; }


        public Int64? QuestionId { get; set; }

        public virtual Question Question { get; set; }

    }
}
