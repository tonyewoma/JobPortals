namespace JobPortals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeeProjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeeProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyTypeId = c.Int(nullable: false),
                        ProjectName = c.String(),
                        ProjectDescription = c.String(),
                        SkillsRequired = c.String(),
                        Budget = c.String(),
                        ProjectDeadline = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ContactPerson = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyTypes", t => t.CompanyTypeId, cascadeDelete: true)
                .Index(t => t.CompanyTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeeProjects", "CompanyTypeId", "dbo.CompanyTypes");
            DropIndex("dbo.SeeProjects", new[] { "CompanyTypeId" });
            DropTable("dbo.SeeProjects");
        }
    }
}
