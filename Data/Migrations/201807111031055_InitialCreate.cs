namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Password = c.String(nullable: false),
                        Image = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserBooks",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Book_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.UserBooks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UserBooks", new[] { "Book_Id" });
            DropIndex("dbo.UserBooks", new[] { "User_Id" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropTable("dbo.UserBooks");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
        }
    }
}
