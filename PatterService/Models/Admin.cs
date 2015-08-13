using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AdminNo { get; set; }
        public string WriteId { get; set; }
        public string Password { get; set; }
        public string WriteName { get; set; }
        public DateTime DateCreated { get; set; }


    }
}