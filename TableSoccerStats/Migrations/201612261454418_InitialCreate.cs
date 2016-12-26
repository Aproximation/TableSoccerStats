namespace TableSoccerStats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        DatePlayed = c.DateTime(nullable: false),
                        Team12Points = c.Int(nullable: false),
                        Team34Points = c.Int(nullable: false),
                        Player1A_PlayerId = c.Int(),
                        Player1B_PlayerId = c.Int(),
                        Player2A_PlayerId = c.Int(),
                        Player2B_PlayerId = c.Int(),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Players", t => t.Player1A_PlayerId)
                .ForeignKey("dbo.Players", t => t.Player1B_PlayerId)
                .ForeignKey("dbo.Players", t => t.Player2A_PlayerId)
                .ForeignKey("dbo.Players", t => t.Player2B_PlayerId)
                .Index(t => t.Player1A_PlayerId)
                .Index(t => t.Player1B_PlayerId)
                .Index(t => t.Player2A_PlayerId)
                .Index(t => t.Player2B_PlayerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        Initials = c.String(nullable: false, maxLength: 4),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Player2B_PlayerId", "dbo.Players");
            DropForeignKey("dbo.Games", "Player2A_PlayerId", "dbo.Players");
            DropForeignKey("dbo.Games", "Player1B_PlayerId", "dbo.Players");
            DropForeignKey("dbo.Games", "Player1A_PlayerId", "dbo.Players");
            DropIndex("dbo.Games", new[] { "Player2B_PlayerId" });
            DropIndex("dbo.Games", new[] { "Player2A_PlayerId" });
            DropIndex("dbo.Games", new[] { "Player1B_PlayerId" });
            DropIndex("dbo.Games", new[] { "Player1A_PlayerId" });
            DropTable("dbo.Players");
            DropTable("dbo.Games");
        }
    }
}
