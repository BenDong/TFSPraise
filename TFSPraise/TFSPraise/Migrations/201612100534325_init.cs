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
                        BlogID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PublisherID = c.String(nullable: false, maxLength: 128),
                        PublishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID)
                .ForeignKey("dbo.Users", t => t.PublisherID, cascadeDelete: true)
                .Index(t => t.PublisherID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Resign = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Praises",
                c => new
                    {
                        PraiseID = c.Int(nullable: false, identity: true),
                        OwnerID = c.String(nullable: false, maxLength: 128),
                        PraiseContent = c.String(),
                        PraiseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PraiseID)
                .ForeignKey("dbo.Users", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Receivers",
                c => new
                    {
                        ReceiverID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Resign = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiverID);
            
            CreateTable(
                "dbo.ReceiverPraises",
                c => new
                    {
                        PraiseID = c.Int(nullable: false),
                        ReceiverID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PraiseID, t.ReceiverID })
                .ForeignKey("dbo.Praises", t => t.PraiseID, cascadeDelete: true)
                .ForeignKey("dbo.Receivers", t => t.ReceiverID, cascadeDelete: true)
                .Index(t => t.PraiseID)
                .Index(t => t.ReceiverID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Praises", "OwnerID", "dbo.Users");
            DropForeignKey("dbo.ReceiverPraises", "ReceiverID", "dbo.Receivers");
            DropForeignKey("dbo.ReceiverPraises", "PraiseID", "dbo.Praises");
            DropForeignKey("dbo.Blogs", "PublisherID", "dbo.Users");
            DropIndex("dbo.ReceiverPraises", new[] { "ReceiverID" });
            DropIndex("dbo.ReceiverPraises", new[] { "PraiseID" });
            DropIndex("dbo.Praises", new[] { "OwnerID" });
            DropIndex("dbo.Blogs", new[] { "PublisherID" });
            DropTable("dbo.ReceiverPraises");
            DropTable("dbo.Receivers");
            DropTable("dbo.Praises");
            DropTable("dbo.Users");
            DropTable("dbo.Blogs");
        }
    }
}
