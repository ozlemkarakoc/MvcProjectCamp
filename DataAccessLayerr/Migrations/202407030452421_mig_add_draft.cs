namespace DataAccessLayerr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_draft : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        DraftID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        Sender = c.String(),
                        Receiver = c.String(),
                    })
                .PrimaryKey(t => t.DraftID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drafts");
        }
    }
}
