using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class Review
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ReviewNo { get; set; }
        public int CompanyNo { get; set; }
        public int MemberNo { get; set; }
        public string Content { get; set; }
        public byte Grade { get; set; }
        public DateTime DateCreated { get; set; }

        // Navigation property
        [ForeignKey("MemberNo")]
        public Member Member { get; set; }
        [ForeignKey("CompanyNo")]
        public Company Company { get; set; }

    }
}