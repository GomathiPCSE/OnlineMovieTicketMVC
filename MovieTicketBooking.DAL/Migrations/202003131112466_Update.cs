namespace MovieTicketBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Theatres",
                c => new
                    {
                        TheatreId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TheatreName = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 50),
                        NoOfScreen = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TheatreId)
                .ForeignKey("dbo.UserInfo", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TheatreName, unique: true);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        MobileNumber = c.Long(nullable: false),
                        MailId = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.MobileNumber, unique: true)
                .Index(t => t.MailId, unique: true);
            
            CreateStoredProcedure(
                "dbo.UserAccount_Insert",
                p => new
                    {
                        FirstName = p.String(maxLength: 30),
                        LastName = p.String(maxLength: 30),
                        MobileNumber = p.Long(),
                        MailId = p.String(maxLength: 50),
                        Password = p.String(maxLength: 20),
                        Role = p.String(),
                    },
                body:
                    @"INSERT [dbo].[UserInfo]([FirstName], [LastName], [MobileNumber], [MailId], [Password], [Role])
                      VALUES (@FirstName, @LastName, @MobileNumber, @MailId, @Password, @Role)
                      
                      DECLARE @UserId int
                      SELECT @UserId = [UserId]
                      FROM [dbo].[UserInfo]
                      WHERE @@ROWCOUNT > 0 AND [UserId] = scope_identity()
                      
                      SELECT t0.[UserId]
                      FROM [dbo].[UserInfo] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[UserId] = @UserId"
            );
            
            CreateStoredProcedure(
                "dbo.UserAccount_Update",
                p => new
                    {
                        UserId = p.Int(),
                        FirstName = p.String(maxLength: 30),
                        LastName = p.String(maxLength: 30),
                        MobileNumber = p.Long(),
                        MailId = p.String(maxLength: 50),
                        Password = p.String(maxLength: 20),
                        Role = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[UserInfo]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [MobileNumber] = @MobileNumber, [MailId] = @MailId, [Password] = @Password, [Role] = @Role
                      WHERE ([UserId] = @UserId)"
            );
            
            CreateStoredProcedure(
                "dbo.UserAccount_Delete",
                p => new
                    {
                        UserId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[UserInfo]
                      WHERE ([UserId] = @UserId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.UserAccount_Delete");
            DropStoredProcedure("dbo.UserAccount_Update");
            DropStoredProcedure("dbo.UserAccount_Insert");
            DropForeignKey("dbo.Theatres", "UserId", "dbo.UserInfo");
            DropIndex("dbo.UserInfo", new[] { "MailId" });
            DropIndex("dbo.UserInfo", new[] { "MobileNumber" });
            DropIndex("dbo.Theatres", new[] { "TheatreName" });
            DropIndex("dbo.Theatres", new[] { "UserId" });
            DropTable("dbo.UserInfo");
            DropTable("dbo.Theatres");
        }
    }
}
