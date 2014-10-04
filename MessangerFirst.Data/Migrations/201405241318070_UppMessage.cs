namespace MessangerFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UppMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Subject", c => c.String());
            AddColumn("dbo.Messages", "Body", c => c.String());
            AddColumn("dbo.Messages", "SenderDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "RecieverDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "RecieverViewed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "Title");
            DropColumn("dbo.Messages", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Content", c => c.String());
            AddColumn("dbo.Messages", "Title", c => c.String());
            DropColumn("dbo.Messages", "RecieverViewed");
            DropColumn("dbo.Messages", "RecieverDeleted");
            DropColumn("dbo.Messages", "SenderDeleted");
            DropColumn("dbo.Messages", "Body");
            DropColumn("dbo.Messages", "Subject");
        }
    }
}
