namespace PatterService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventPictures : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.EventPicutreNo)
                .ForeignKey("dbo.Events", t => t.EventNo, cascadeDelete: true)
                .Index(t => t.EventNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventPictures", "EventNo", "dbo.Events");
            DropIndex("dbo.EventPictures", new[] { "EventNo" });
            DropTable("dbo.EventPictures");
        }
    }
}
