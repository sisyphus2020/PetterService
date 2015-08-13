using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NotificationNo { get; set; }
        public string WriteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PictureName { get; set; }
        public string PicturePath { get; set; }

        // Navigation property
        //[ForeignKey("WriteId")]
        //public Admin Admin { get; set; }
    }
}