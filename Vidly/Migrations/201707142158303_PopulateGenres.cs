namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Romance')");

        }
        
        public override void Down()
        {
        }
    }
}
