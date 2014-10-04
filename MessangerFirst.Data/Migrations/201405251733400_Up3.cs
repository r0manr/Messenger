namespace MessangerFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Up3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PhoneNumber");
        }
    }
}
