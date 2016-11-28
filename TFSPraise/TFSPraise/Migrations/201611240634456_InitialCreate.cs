namespace TFSPraise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogNo = c.Int(nullable: false, identity: true),
                        OwnerID = c.String(),
                        Content = c.String(),
                        BlogTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogNo);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ResignFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Praises",
                c => new
                    {
                        PraiseID = c.Int(nullable: false, identity: true),
                        OwnerID = c.String(),
                        ReceivierID = c.String(),
                        Content = c.String(),
                        PraiseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PraiseID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Praises");
            DropTable("dbo.Employees");
            DropTable("dbo.Blogs");
        }
    }
}
