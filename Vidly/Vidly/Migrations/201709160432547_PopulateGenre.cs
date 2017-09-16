namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT Genres (Name) VALUES ('Action')");
            Sql("INSERT Genres (Name) VALUES ('Animation')");
            Sql("INSERT Genres (Name) VALUES ('Comedy')");
            Sql("INSERT Genres (Name) VALUES ('Family')");
            Sql("INSERT Genres (Name) VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
