﻿namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        UrlSlug = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1024),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        ShortDescription = c.String(maxLength: 1024),
                        PostContent = c.String(nullable: false, maxLength: 1024),
                        UrlSlug = c.String(nullable: false, maxLength: 255),
                        Published = c.String(nullable: false, maxLength: 255),
                        PostedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CategoryId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.PostTagMaps",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        UrlSlug = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1024),
                        Count = c.Int(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTagMaps", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PostTagMaps", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.PostTagMaps", new[] { "TagId" });
            DropIndex("dbo.PostTagMaps", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropTable("dbo.Tags");
            DropTable("dbo.PostTagMaps");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
