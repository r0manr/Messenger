namespace MessangerFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Messages", name: "AddresseeId", newName: "RecieverId");
            RenameIndex(table: "dbo.Messages", name: "IX_AddresseeId", newName: "IX_RecieverId");
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            DropColumn("dbo.Users", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Login", c => c.String());
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "Email");
            RenameIndex(table: "dbo.Messages", name: "IX_RecieverId", newName: "IX_AddresseeId");
            RenameColumn(table: "dbo.Messages", name: "RecieverId", newName: "AddresseeId");
        }
    }
}
