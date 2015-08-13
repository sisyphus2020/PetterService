using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class PatterServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PatterServiceContext() : base("name=PatterServiceContext")
        {
        }

        public System.Data.Entity.DbSet<PatterService.Models.Member> Members { get; set; }

        //public System.Data.Entity.DbSet<PatterService.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.Review> Reviews { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.ReviewPicture> ReviewPictures { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.Gallery> Galleries { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.Admin> Admins { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.Notification> Notifications { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.GalleryPicture> GalleryPictures { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.GalleryComment> GalleryComments { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.Evaluation> Evaluations { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.EvaluationDetail> EvaluationDetails { get; set; }

        public System.Data.Entity.DbSet<PatterService.Models.EventPicture> EventPictures { get; set; }
    }
}
