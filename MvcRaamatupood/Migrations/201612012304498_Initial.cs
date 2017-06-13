namespace MvcRaamatupood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Raamatupoods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Pealkiri = c.String(),
                        Autor = c.String(),
                        IlmumisAasta = c.DateTime(nullable: false),
                        Kirjastus = c.String(),
                        Hind = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Raamatupoods");
        }
    }
}
