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

        public Int64 ID { get; set; }
        public byte Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ModifieldBy { get; set; }
        public DateTime ModifieldDate { get; set; } = DateTime.Now;
    }
}
