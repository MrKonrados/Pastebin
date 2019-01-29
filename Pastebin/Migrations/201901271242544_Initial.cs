namespace Pastebin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pastes",
                c => new
                    {
                        PasteId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Content = c.String(),
                        URI = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.PasteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pastes");
        }
    }
}
