namespace Fil_rouge_evente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projetMergeFinal2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Roles", "Droit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "Droit", c => c.Int(nullable: false));
        }
    }
}
