using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class EvaluationDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EvaluationDetailNo { get; set; }
        public int EvaluationNo { get; set; }
        public int MemberNo { get; set; }
        public int Grad { get; set; }

        // Navigation property
        [ForeignKey("EvaluationNo")]
        public Evaluation Evaluation { get; set; }
        [ForeignKey("MemberNo")]
        public Member Member { get; set; }
    }
}