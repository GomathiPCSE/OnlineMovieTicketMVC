namespace MovieTicketBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserInfo", new[] { "MailId" });
            CreateTable(
                "dbo.AdminAccounts",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Theatres",
                c => new
                    {
                        TheatreId = c.Int(nullable: false, identity: true),
                        TheatreName = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 50),
                        NoOfScreen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TheatreId)
                .Index(t => t.TheatreName, unique: true);
            
            AddColumn("dbo.UserInfo", "UserName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.UserInfo", "UserName", unique: true);
            DropColumn("dbo.UserInfo", "MailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfo", "MailId", c => c.String(nullable: false, maxLength: 36));
            DropIndex("dbo.UserInfo", new[] { "UserName" });
            DropIndex("dbo.Theatres", new[] { "TheatreName" });
            DropColumn("dbo.UserInfo", "UserName");
            DropTable("dbo.Theatres");
            DropTable("dbo.AdminAccounts");
            CreateIndex("dbo.UserInfo", "MailId", unique: true);
        }
    }
}
