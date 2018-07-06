namespace JobPortals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingCom_typeFromCompanyReg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CompanyRegs", "Com_type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyRegs", "Com_type", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
