namespace JobPortals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'31894537-4628-4d07-92ff-da0b31db45bb', N'admin@gmail.com', 0, N'AP1LT+V5LRqrEIeSRfS9+GHwk5i+83HzTrhx9cq/mlI8Xdv5FSiJygODW9gIawnM/w==', N'2bbc1e34-db3b-43eb-8000-85215a4bd2a5', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4f0b386c-fcbd-4d02-a296-853d0b72e4db', N'guest@gmail.com', 0, N'AGleJerPaIzJP+fdKl4xoNKHFX5Dbo9KD2+ha1ApqhRemcXd8MqQKn0mTCxeY74ZEQ==', N'd676e92d-ef45-42c8-9b03-614e0c5b2592', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'011fb894-5bf9-4ef0-8c9e-a81974596cd9', N'CanManageJobs')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'31894537-4628-4d07-92ff-da0b31db45bb', N'011fb894-5bf9-4ef0-8c9e-a81974596cd9')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
