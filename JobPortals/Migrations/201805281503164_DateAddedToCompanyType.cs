namespace JobPortals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateAddedToCompanyType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyTypes", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CompanyTypes", "CompanyTypeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyTypes", "CompanyTypeName", c => c.String());
            DropColumn("dbo.CompanyTypes", "DateAdded");
        }
    }
}
