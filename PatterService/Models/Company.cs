using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class Company
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CompanyNo { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddr { get; set; }
        public string StartShopHours { get; set; }
        public string EndShopHours { get; set; }
        public string Holiday { get; set; }
        public string Introduction { get; set; }
        public DbGeography Geo { get; set; }

    }
}