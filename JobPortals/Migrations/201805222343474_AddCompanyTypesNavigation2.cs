namespace JobPortals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyTypesNavigation2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyRegs", "CompanyType_Id", "dbo.CompanyTypes");
            DropIndex("dbo.CompanyRegs", new[] { "CompanyType_Id" });
            RenameColumn(table: "dbo.CompanyRegs", name: "CompanyType_Id", newName: "CompanyTypeId");
            AlterColumn("dbo.CompanyRegs", "CompanyTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.CompanyRegs", "CompanyTypeId");
            AddForeignKey("dbo.CompanyRegs", "CompanyTypeId", "dbo.CompanyTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyRegs", "CompanyTypeId", "dbo.CompanyTypes");
            DropIndex("dbo.CompanyRegs", new[] { "CompanyTypeId" });
            AlterColumn("dbo.CompanyRegs", "CompanyTypeId", c => c.Int());
            RenameColumn(table: "dbo.CompanyRegs", name: "CompanyTypeId", newName: "CompanyType_Id");
            CreateIndex("dbo.CompanyRegs", "CompanyType_Id");
            AddForeignKey("dbo.CompanyRegs", "CompanyType_Id", "dbo.CompanyTypes", "Id");
        }
    }
}
