namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerFormViewModel", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerFormViewModel", "Name", c => c.String());
        }
    }
}
