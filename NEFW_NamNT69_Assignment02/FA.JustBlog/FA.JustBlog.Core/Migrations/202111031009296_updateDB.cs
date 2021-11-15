namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        PostId = c.Int(nullable: false),
                        CommentHeader = c.String(nullable: false, maxLength: 1024),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            AddColumn("dbo.Posts", "ViewCount", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "RateCount", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "TotalRate", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropColumn("dbo.Posts", "Rate");
            DropColumn("dbo.Posts", "TotalRate");
            DropColumn("dbo.Posts", "RateCount");
            DropColumn("dbo.Posts", "ViewCount");
            DropTable("dbo.Comments");
        }
    }
}
