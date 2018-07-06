namespace JobPortals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyTypesNavigation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyRegs", "CompanyType_Id", c => c.Int());
            CreateIndex("dbo.CompanyRegs", "CompanyType_Id");
            AddForeignKey("dbo.CompanyRegs", "CompanyType_Id", "dbo.CompanyTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyRegs", "CompanyType_Id", "dbo.CompanyTypes");
            DropIndex("dbo.CompanyRegs", new[] { "CompanyType_Id" });
            DropColumn("dbo.CompanyRegs", "CompanyType_Id");
        }
    }
}
