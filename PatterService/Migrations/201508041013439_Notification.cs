namespace PatterService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationNo = c.Int(nullable: false, identity: true),
                        WriteId = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        PictureName = c.String(),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.NotificationNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}
