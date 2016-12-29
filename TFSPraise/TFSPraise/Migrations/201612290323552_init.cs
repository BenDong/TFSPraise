namespace TFSPraise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PosterID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.UserProfiles", t => t.PosterID, cascadeDelete: true)
                .Index(t => t.PosterID);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        IdentityID = c.Int(nullable: false, identity: true),
                        Resign = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdentityID);
            
            CreateTable(
                "dbo.Identities",
                c => new
                    {
                        IdentityID = c.Int(nullable: false),
                        Name = c.String(),
                        DispalyName = c.String(),
                    })
                .PrimaryKey(t => t.IdentityID)
                .ForeignKey("dbo.UserProfiles", t => t.IdentityID, cascadeDelete: true)
                .Index(t => t.IdentityID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikeID = c.Int(nullable: false, identity: true),
                        SponsorID = c.Int(nullable: false),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LikeID)
                .ForeignKey("dbo.UserProfiles", t => t.SponsorID, cascadeDelete: true)
                .Index(t => t.SponsorID);
            
            CreateTable(
                "dbo.Receivers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReceiverLikeMapping",
                c => new
                    {
                        LikeID = c.Int(nullable: false),
                        ReceiverID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LikeID, t.ReceiverID })
                .ForeignKey("dbo.Likes", t => t.LikeID, cascadeDelete: true)
                .ForeignKey("dbo.Receivers", t => t.ReceiverID, cascadeDelete: true)
                .Index(t => t.LikeID)
                .Index(t => t.ReceiverID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "SponsorID", "dbo.UserProfiles");
            DropForeignKey("dbo.ReceiverLikeMapping", "ReceiverID", "dbo.Receivers");
            DropForeignKey("dbo.ReceiverLikeMapping", "LikeID", "dbo.Likes");
            DropForeignKey("dbo.Identities", "IdentityID", "dbo.UserProfiles");
            DropForeignKey("dbo.Blogs", "PosterID", "dbo.UserProfiles");
            DropIndex("dbo.ReceiverLikeMapping", new[] { "ReceiverID" });
            DropIndex("dbo.ReceiverLikeMapping", new[] { "LikeID" });
            DropIndex("dbo.Likes", new[] { "SponsorID" });
            DropIndex("dbo.Identities", new[] { "IdentityID" });
            DropIndex("dbo.Blogs", new[] { "PosterID" });
            DropTable("dbo.ReceiverLikeMapping");
            DropTable("dbo.Receivers");
            DropTable("dbo.Likes");
            DropTable("dbo.Identities");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Blogs");
        }
    }
}
