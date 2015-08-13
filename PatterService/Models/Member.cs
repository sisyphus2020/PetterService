using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class Member
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MemberNo { get; set; }
        public string MemberName { get; set; }
        public string ProfilePicture { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }

    }
}