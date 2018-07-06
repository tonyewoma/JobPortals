namespace JobPortals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vacancies1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vacancies", "CompanyRegId", "dbo.CompanyRegs");
            DropIndex("dbo.Vacancies", new[] { "CompanyRegId" });
            AddColumn("dbo.Vacancies", "CompanyName", c => c.String());
            AddColumn("dbo.Vacancies", "AboutCompany", c => c.String());
            AddColumn("dbo.Vacancies", "CompanyTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Vacancies", "Postion", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Vacancies", "JobType", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Vacancies", "Qualification", c => c.String(nullable: false));
            AddColumn("dbo.Vacancies", "Responsibility", c => c.String(nullable: false));
            AddColumn("dbo.Vacancies", "SkillsRequired", c => c.String(nullable: false));
            AddColumn("dbo.Vacancies", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vacancies", "Location", c => c.String(nullable: false));
            CreateIndex("dbo.Vacancies", "CompanyTypeId");
            AddForeignKey("dbo.Vacancies", "CompanyTypeId", "dbo.CompanyTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Vacancies", "CompanyRegId");
            DropColumn("dbo.Vacancies", "Post");
            DropColumn("dbo.Vacancies", "Description");
            DropColumn("dbo.Vacancies", "No_vacancy");
            DropColumn("dbo.Vacancies", "Industry");
            DropColumn("dbo.Vacancies", "Gender");
            DropColumn("dbo.Vacancies", "Skill_area");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vacancies", "Skill_area", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Vacancies", "Gender", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Vacancies", "Industry", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Vacancies", "No_vacancy", c => c.Int(nullable: false));
            AddColumn("dbo.Vacancies", "Description", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Vacancies", "Post", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Vacancies", "CompanyRegId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Vacancies", "CompanyTypeId", "dbo.CompanyTypes");
            DropIndex("dbo.Vacancies", new[] { "CompanyTypeId" });
            AlterColumn("dbo.Vacancies", "Location", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Vacancies", "DateAdded");
            DropColumn("dbo.Vacancies", "SkillsRequired");
            DropColumn("dbo.Vacancies", "Responsibility");
            DropColumn("dbo.Vacancies", "Qualification");
            DropColumn("dbo.Vacancies", "JobType");
            DropColumn("dbo.Vacancies", "Postion");
            DropColumn("dbo.Vacancies", "CompanyTypeId");
            DropColumn("dbo.Vacancies", "AboutCompany");
            DropColumn("dbo.Vacancies", "CompanyName");
            CreateIndex("dbo.Vacancies", "CompanyRegId");
            AddForeignKey("dbo.Vacancies", "CompanyRegId", "dbo.CompanyRegs", "Id", cascadeDelete: true);
        }
    }
}
