namespace MovieTicketBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false, maxLength: 40),
                        MovieHour = c.DateTime(nullable: false),
                        MovieType = c.String(nullable: false, maxLength: 30),
                        MovieDescription = c.String(nullable: false, maxLength: 50),
                        TheatreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Theatres", t => t.TheatreId, cascadeDelete: true)
                .Index(t => t.TheatreId);
            
            CreateTable(
                "dbo.Theatres",
                c => new
                    {
                        TheatreId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TheatreName = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 50),
                        NoOfScreen = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.TheatreId)
                .ForeignKey("dbo.UserInfo", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                        Role = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.MobileNumber, unique: true)
                .Index(t => t.MailId, unique: true);
            
            CreateStoredProcedure(
                "dbo.Movie_Insert",
                p => new
                    {
                        MovieName = p.String(maxLength: 40),
                        MovieHour = p.DateTime(),
                        MovieType = p.String(maxLength: 30),
                        MovieDescription = p.String(maxLength: 50),
                        TheatreId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Movies]([MovieName], [MovieType], [Language], [Certificate], [MovieHour], [MovieDescription], [TheatreId])
                      VALUES (@MovieName, @MovieType, NULL, NULL, @MovieHour, @MovieDescription, @TheatreId)
                      
                      DECLARE @MovieId int
                      SELECT @MovieId = [MovieId]
                      FROM [dbo].[Movies]
                      WHERE @@ROWCOUNT > 0 AND [MovieId] = scope_identity()
                      
                      SELECT t0.[MovieId]
                      FROM [dbo].[Movies] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[MovieId] = @MovieId"
            );
            
            CreateStoredProcedure(
                "dbo.Movie_Update",
                p => new
                    {
                        MovieId = p.Int(),
                        MovieName = p.String(maxLength: 40),
                        MovieHour = p.DateTime(),
                        MovieType = p.String(maxLength: 30),
                        MovieDescription = p.String(maxLength: 50),
                        TheatreId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Movies]
                      SET [MovieName] = @MovieName, [MovieType] = @MovieType, [Language] = NULL, [Certificate] = NULL, [MovieHour] = @MovieHour, [MovieDescription] = @MovieDescription, [TheatreId] = @TheatreId
                      WHERE ([MovieId] = @MovieId)"
            );
            
            CreateStoredProcedure(
                "dbo.Movie_Delete",
                p => new
                    {
                        MovieId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Movies]
                      WHERE ([MovieId] = @MovieId)"
            );
            
            CreateStoredProcedure(
                "dbo.UserAccount_Insert",
                p => new
                    {
                        FirstName = p.String(maxLength: 30),
                        LastName = p.String(maxLength: 30),
                        MobileNumber = p.Long(),
                        MailId = p.String(maxLength: 50),
                        Password = p.String(maxLength: 20),
                        Role = p.String(maxLength: 15),
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
                        Role = p.String(maxLength: 15),
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
            DropStoredProcedure("dbo.Movie_Delete");
            DropStoredProcedure("dbo.Movie_Update");
            DropStoredProcedure("dbo.Movie_Insert");
            DropForeignKey("dbo.Movies", "TheatreId", "dbo.Theatres");
            DropForeignKey("dbo.Theatres", "UserId", "dbo.UserInfo");
            DropIndex("dbo.UserInfo", new[] { "MailId" });
            DropIndex("dbo.UserInfo", new[] { "MobileNumber" });
            DropIndex("dbo.Theatres", new[] { "UserId" });
            DropIndex("dbo.Movies", new[] { "TheatreId" });
            DropTable("dbo.UserInfo");
            DropTable("dbo.Theatres");
            DropTable("dbo.Movies");
        }
    }
}
