namespace Anagrams.EFCF.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLogs", "Action", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserLogs", "Action");
        }
    }
}
