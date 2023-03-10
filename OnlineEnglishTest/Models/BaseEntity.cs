using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace OnlineEnglishTest.Models
{
    [Table("BaseEntity")]
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }

        [Column(TypeName = "tinyint")]
        [AllowNull]
        public byte? Status { get; set; }


        [StringLength(500)]
        [AllowNull]
        public string? CreatedBy { get; set; }


        [Column(TypeName="datetime")]
        [AllowNull]
        public DateTime? CreatedDate { get; set; }


        [StringLength(500)]
        [AllowNull]

        public string? ModifieldBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifieldDate { get; set; }
    }
}
