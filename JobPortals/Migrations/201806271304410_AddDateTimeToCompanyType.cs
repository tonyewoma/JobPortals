namespace JobPortals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeToCompanyType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyTypes", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyTypes", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
