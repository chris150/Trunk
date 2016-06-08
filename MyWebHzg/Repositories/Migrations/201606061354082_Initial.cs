namespace MyWebHzg.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        ActorId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Birthdate = c.DateTime(),
                        Gender = c.Boolean(),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 128),
                        GenreId = c.Guid(nullable: false),
                        MediumTypeId = c.Guid(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Genre", t => t.GenreId)
                .ForeignKey("dbo.MediumTypeTab", t => t.MediumTypeId)
                .Index(t => t.GenreId)
                .Index(t => t.MediumTypeId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Guid(nullable: false),
                        GenreCd = c.String(maxLength: 8),
                        Bez = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.MediumTypeTab",
                c => new
                    {
                        MediumTypeId = c.Guid(nullable: false),
                        Bez = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.MediumTypeId);
            
            CreateTable(
                "dbo.MovieActor",
                c => new
                    {
                        Movie_MovieId = c.Guid(nullable: false),
                        Actor_ActorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieId, t.Actor_ActorId })
                .ForeignKey("dbo.Movie", t => t.Movie_MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Actor", t => t.Actor_ActorId, cascadeDelete: true)
                .Index(t => t.Movie_MovieId)
                .Index(t => t.Actor_ActorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "MediumTypeId", "dbo.MediumTypeTab");
            DropForeignKey("dbo.Movie", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.MovieActor", "Actor_ActorId", "dbo.Actor");
            DropForeignKey("dbo.MovieActor", "Movie_MovieId", "dbo.Movie");
            DropIndex("dbo.MovieActor", new[] { "Actor_ActorId" });
            DropIndex("dbo.MovieActor", new[] { "Movie_MovieId" });
            DropIndex("dbo.Movie", new[] { "MediumTypeId" });
            DropIndex("dbo.Movie", new[] { "GenreId" });
            DropTable("dbo.MovieActor");
            DropTable("dbo.MediumTypeTab");
            DropTable("dbo.Genre");
            DropTable("dbo.Movie");
            DropTable("dbo.Actor");
        }
    }
}
