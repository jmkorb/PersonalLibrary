namespace PersonalLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPocos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Author", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Author", "BirthDate");
        }
    }
}
