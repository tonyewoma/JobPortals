namespace JobPortals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vacancies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyRegId = c.Int(nullable: false),
                        Post = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 255),
                        No_vacancy = c.Int(nullable: false),
                        Location = c.String(nullable: false, maxLength: 100),
                        Experience = c.String(nullable: false),
                        Industry = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 50),
                        Skill_area = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyRegs", t => t.CompanyRegId, cascadeDelete: true)
                .Index(t => t.CompanyRegId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancies", "CompanyRegId", "dbo.CompanyRegs");
            DropIndex("dbo.Vacancies", new[] { "CompanyRegId" });
            DropTable("dbo.Vacancies");
        }
    }
}
