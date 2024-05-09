namespace DataAccessLayerr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_contactadddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactDate");
        }
    }
}
