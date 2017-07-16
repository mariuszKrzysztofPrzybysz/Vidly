namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerFormViewModel", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerFormViewModel", "Name");
        }
    }
}
