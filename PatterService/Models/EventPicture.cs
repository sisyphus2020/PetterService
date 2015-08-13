using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class EventPicture
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EventPicutreNo { get; set; }
        public int EventNo { get; set; }
        public string PictureName { get; set; }
        public string PicturePath { get; set; }

        // Navigation property
        [ForeignKey("EventNo")]
        public Event Event { get; set; }
    }
}