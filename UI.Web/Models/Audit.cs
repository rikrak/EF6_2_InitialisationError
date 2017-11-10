using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI.Web.Models
{
    public class Audit
    {
        public Audit()
        {
            AuditTime = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime AuditTime { get; protected set; }
    }
}