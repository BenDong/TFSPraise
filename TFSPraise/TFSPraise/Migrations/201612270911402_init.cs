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
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PublisherID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserProfiles", t => t.PublisherID, cascadeDelete: true)
                .Index(t => t.PublisherID);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Resign = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.Praises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Int(nullable: false),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserProfiles", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Receivers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        Resign = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReceiverPraises",
                c => new
                    {
                        PraiseID = c.Int(nullable: false),
                        ReceiverID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PraiseID, t.ReceiverID })
                .ForeignKey("dbo.Praises", t => t.PraiseID, cascadeDelete: true)
                .ForeignKey("dbo.Receivers", t => t.ReceiverID, cascadeDelete: true)
                .Index(t => t.PraiseID)
                .Index(t => t.ReceiverID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Praises", "OwnerID", "dbo.UserProfiles");
            DropForeignKey("dbo.ReceiverPraises", "ReceiverID", "dbo.Receivers");
            DropForeignKey("dbo.ReceiverPraises", "PraiseID", "dbo.Praises");
            DropForeignKey("dbo.Identities", "IdentityID", "dbo.UserProfiles");
            DropForeignKey("dbo.Blogs", "PublisherID", "dbo.UserProfiles");
            DropIndex("dbo.ReceiverPraises", new[] { "ReceiverID" });
            DropIndex("dbo.ReceiverPraises", new[] { "PraiseID" });
            DropIndex("dbo.Praises", new[] { "OwnerID" });
            DropIndex("dbo.Identities", new[] { "IdentityID" });
            DropIndex("dbo.Blogs", new[] { "PublisherID" });
            DropTable("dbo.ReceiverPraises");
            DropTable("dbo.Receivers");
            DropTable("dbo.Praises");
            DropTable("dbo.Identities");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Blogs");
        }
    }
}
