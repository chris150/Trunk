namespace MyWebHzg.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aktualValueAllg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActualValueAllgs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        Witterungstemperatur = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ActualValueAllgs");
        }
    }
}
