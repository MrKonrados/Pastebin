namespace Pastebin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLanguageIdToPasteModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pastes", "LanguageId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pastes", "LanguageId");
        }
    }
}
