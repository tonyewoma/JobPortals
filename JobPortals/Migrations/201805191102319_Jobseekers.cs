namespace JobPortals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobseekers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobseekers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        J_Name = c.String(nullable: false, maxLength: 100),
                        J_Email = c.String(nullable: false, maxLength: 100),
                        J_Address = c.String(nullable: false, maxLength: 150),
                        J_DOB = c.DateTime(nullable: false),
                        J_City = c.String(nullable: false, maxLength: 150),
                        J_Cnumber = c.String(nullable: false, maxLength: 150),
                        J_Country = c.String(nullable: false, maxLength: 150),
                        J_Gender = c.String(nullable: false, maxLength: 150),
                        J_State = c.String(nullable: false, maxLength: 150),
                        Extra_achi = c.String(nullable: false, maxLength: 150),
                        User_type = c.String(nullable: false, maxLength: 150),
                        Skill_area = c.String(nullable: false, maxLength: 150),
                        Exp_detail = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Jobseekers");
        }
    }
}
