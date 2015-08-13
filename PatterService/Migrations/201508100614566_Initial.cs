namespace PatterService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.EventPictures", "EventNo", "dbo.Events");
            //DropIndex("dbo.EventPictures", new[] { "EventNo" });
            //DropTable("dbo.EventPictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventPictures",
                c => new
                    {
                        EventPicutreNo = c.Int(nullable: false, identity: true),
                        EventNo = c.Int(nullable: false),
                        PictureName = c.String(),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.EventPicutreNo);
            
            CreateIndex("dbo.EventPictures", "EventNo");
            AddForeignKey("dbo.EventPictures", "EventNo", "dbo.Events", "EventNo", cascadeDelete: true);
        }
    }
}
