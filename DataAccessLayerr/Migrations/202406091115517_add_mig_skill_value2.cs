namespace DataAccessLayerr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_skill_value2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Value2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "Value2");
        }
    }
}
