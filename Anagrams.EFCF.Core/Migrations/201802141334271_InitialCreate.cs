namespace Anagrams.EFCF.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CachedWords",
                c => new
                    {
                        CachedWordID = c.Int(nullable: false, identity: true),
                        CachedWord1 = c.String(),
                    })
                .PrimaryKey(t => t.CachedWordID);
            
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        IP_address = c.String(),
                        CachedWordID = c.Int(nullable: false),
                        SearchTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CachedWords", t => t.CachedWordID, cascadeDelete: true)
                .Index(t => t.CachedWordID);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Word1 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CachedAnagrams",
                c => new
                    {
                        CachedWordID = c.Int(nullable: false),
                        AnagramID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CachedWordID, t.AnagramID })
                .ForeignKey("dbo.CachedWords", t => t.CachedWordID, cascadeDelete: true)
                .ForeignKey("dbo.Words", t => t.AnagramID, cascadeDelete: true)
                .Index(t => t.CachedWordID)
                .Index(t => t.AnagramID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CachedAnagrams", "AnagramID", "dbo.Words");
            DropForeignKey("dbo.CachedAnagrams", "CachedWordID", "dbo.CachedWords");
            DropForeignKey("dbo.UserLogs", "CachedWordID", "dbo.CachedWords");
            DropIndex("dbo.CachedAnagrams", new[] { "AnagramID" });
            DropIndex("dbo.CachedAnagrams", new[] { "CachedWordID" });
            DropIndex("dbo.UserLogs", new[] { "CachedWordID" });
            DropTable("dbo.CachedAnagrams");
            DropTable("dbo.Words");
            DropTable("dbo.UserLogs");
            DropTable("dbo.CachedWords");
        }
    }
}
