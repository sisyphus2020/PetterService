using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class Gallery
    {
        [Key]
        public int GalleryNo { get; set; }
        public int CompanyNo { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }

        [ForeignKey("CompanyNo")]
        public Company Company { get; set; }
    }
}