namespace MovieTicketBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingTables",
                c => new
                    {
                        BookingTableId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Show = c.Int(nullable: false),
                        DateToPresent = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingTableId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingTables", "MovieId", "dbo.Movies");
            DropIndex("dbo.BookingTables", new[] { "MovieId" });
            DropTable("dbo.BookingTables");
        }
    }
}
