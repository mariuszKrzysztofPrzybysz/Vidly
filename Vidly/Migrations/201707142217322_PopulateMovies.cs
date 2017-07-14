namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('The Terminator', 1, '1999-12-12', '2000-02-05', 1)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('They', 2, '1999-11-12', '2000-02-05', 17)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('IT', 3, '1999-04-12', '2007-02-05', 15)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('The King Kong', 4, '1999-08-12', '2009-02-05', 31)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Romeo and Juliet', 5, '2000-12-12', '2012-02-05', 71)");
        }
        
        public override void Down()
        {
        }
    }
}
