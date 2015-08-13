using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class ReviewPicture
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ReviewNo { get; set; }
        public string PictureName { get; set; }
        public string PicturePath { get; set; }

        // Foreign Key
        // public int ReviewNo { get; set; }

        // Navigation property
        [ForeignKey("ReviewNo")]
        public Review Review { get; set; }

    }
}