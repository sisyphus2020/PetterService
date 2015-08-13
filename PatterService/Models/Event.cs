using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class Event
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EventNo { get; set; }
        public string WriteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
        //Navigation property
        public List<EventPicture> EventPictures { get; set; }
    }
}