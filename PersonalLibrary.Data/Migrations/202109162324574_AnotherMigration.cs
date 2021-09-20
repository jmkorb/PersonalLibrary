namespace PersonalLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Genre", "CreatedDate");
            DropColumn("dbo.Genre", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genre", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Genre", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
