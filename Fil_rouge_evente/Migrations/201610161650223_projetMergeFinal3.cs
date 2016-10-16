namespace Fil_rouge_evente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projetMergeFinal3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Droit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "Droit");
        }
    }
}
