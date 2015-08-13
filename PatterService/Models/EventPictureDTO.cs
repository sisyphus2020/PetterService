using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class EventPictureDTO
    {
        public int EventPicutreNo { get; set; }
        public int EventNo { get; set; }
        public string PictureName { get; set; }
        public string PicturePath { get; set; }
    }
}