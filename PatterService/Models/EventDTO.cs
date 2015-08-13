using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class EventDTO
    {
        [Key]
        public int EventNo { get; set; }
        public string WriteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<EventPicture> EventPictures { get; set; }
    }
}