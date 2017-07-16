namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE CustomerFormViewModel SET Name = 'Pay as You Go' WHERE DurationInMonths = 0");
            Sql("UPDATE CustomerFormViewModel SET Name = 'Monthly' WHERE DurationInMonths = 1");
            Sql("UPDATE CustomerFormViewModel SET Name = 'Quarterly' WHERE DurationInMonths = 3");
            Sql("UPDATE CustomerFormViewModel SET Name = 'Annually' WHERE DurationInMonths = 12");
        }
        
        public override void Down()
        {
        }
    }
}
