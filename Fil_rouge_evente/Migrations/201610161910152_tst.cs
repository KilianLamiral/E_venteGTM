namespace Fil_rouge_evente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tst : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produits", "CategorieId", "dbo.Categories");
            DropIndex("dbo.Produits", new[] { "CategorieId" });
            AddColumn("dbo.Produits", "Categorie", c => c.String(nullable: false));
            AlterColumn("dbo.Avis_ClientProduit", "Note", c => c.Int(nullable: false));
            DropColumn("dbo.Produits", "CategorieId");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieId = c.Int(nullable: false, identity: true),
                        NomCategorie = c.String(),
                    })
                .PrimaryKey(t => t.CategorieId);
            
            AddColumn("dbo.Produits", "CategorieId", c => c.Int(nullable: false));
            AlterColumn("dbo.Avis_ClientProduit", "Note", c => c.Single(nullable: false));
            DropColumn("dbo.Produits", "Categorie");
            CreateIndex("dbo.Produits", "CategorieId");
            AddForeignKey("dbo.Produits", "CategorieId", "dbo.Categories", "CategorieId", cascadeDelete: true);
        }
    }
}
