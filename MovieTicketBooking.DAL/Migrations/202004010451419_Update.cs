namespace MovieTicketBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Language", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Movies", "Certificate", c => c.String(nullable: false, maxLength: 3));
            AlterStoredProcedure(
                "dbo.Movie_Insert",
                p => new
                    {
                        MovieName = p.String(maxLength: 40),
                        MovieType = p.String(maxLength: 30),
                        Language = p.String(maxLength: 15),
                        Certificate = p.String(maxLength: 3),
                        MovieHour = p.DateTime(),
                        MovieDescription = p.String(maxLength: 50),
                        TheatreId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Movies]([MovieName], [MovieType], [Language], [Certificate], [MovieHour], [MovieDescription], [TheatreId])
                      VALUES (@MovieName, @MovieType, @Language, @Certificate, @MovieHour, @MovieDescription, @TheatreId)
                      
                      DECLARE @MovieId int
                      SELECT @MovieId = [MovieId]
                      FROM [dbo].[Movies]
                      WHERE @@ROWCOUNT > 0 AND [MovieId] = scope_identity()
                      
                      SELECT t0.[MovieId]
                      FROM [dbo].[Movies] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[MovieId] = @MovieId"
            );
            
            AlterStoredProcedure(
                "dbo.Movie_Update",
                p => new
                    {
                        MovieId = p.Int(),
                        MovieName = p.String(maxLength: 40),
                        MovieType = p.String(maxLength: 30),
                        Language = p.String(maxLength: 15),
                        Certificate = p.String(maxLength: 3),
                        MovieHour = p.DateTime(),
                        MovieDescription = p.String(maxLength: 50),
                        TheatreId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Movies]
                      SET [MovieName] = @MovieName, [MovieType] = @MovieType, [Language] = @Language, [Certificate] = @Certificate, [MovieHour] = @MovieHour, [MovieDescription] = @MovieDescription, [TheatreId] = @TheatreId
                      WHERE ([MovieId] = @MovieId)"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Certificate");
            DropColumn("dbo.Movies", "Language");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
