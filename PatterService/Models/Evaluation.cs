using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class Evaluation
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EvaluationNo { get; set; }
        public int CompanyNo { get; set; }
        public byte category { get; set; }
        public int TotalGrad { get; set; }

        // Navigation property
        [ForeignKey("CompanyNo")]
        public Company Company { get; set; }
    }
}