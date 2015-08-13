using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class GalleryPicture
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GalleryNo { get; set; }
        public string GalleryName { get; set; }
        public string GalleryPath { get; set; }

        // Navigation property
        [ForeignKey("GalleryNo")]
        public Gallery Gallery { get; set; }
    }
}