using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class GalleryComment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GalleryCommentNo { get; set; }
        public int GalleryNo { get; set; }
        public int MemberNo { get; set; }
        public string Comment { get; set; }
        public DateTime CommentCreated { get; set; }

        // Navigation property
        [ForeignKey("GalleryNo")]
        public Gallery Gallery { get; set; }
        [ForeignKey("MemberNo")]
        public Member Member { get; set; }
    }
}