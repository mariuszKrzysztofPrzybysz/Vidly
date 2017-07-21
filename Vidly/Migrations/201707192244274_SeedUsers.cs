using Vidly.Models;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aa49ed1b-9004-4e14-bce0-3581a76fddd4', N'admin@vidly.com', 0, N'AC8qUPv6i/3Lb1n8AtqBTNn24ej7UHNa8+Er8aRjH1jrMHHp/whqk8uq3HErzBTyjQ==', N'77d373f3-0422-471f-8f66-5a52d7d373d6', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b7ba1ad5-3798-430a-b157-e447ea25beb9', N'guest@vidly.com', 0, N'AEWMTWmaG6OmuVNNu7ChOCF509Tz0Gsgi40nAS8k0fguSgxkXfqrmyoIUX9SoqKomg==', N'79eb35a4-18e5-4615-bd10-64b7e34866f6', NULL, 0, 0, NULL, 1, 0, N'mariusz.krzysztof.przybysz@gmail.com')");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dd613a84-fe75-40a4-9549-31747526d952', N'" +
                RoleName.CanManageMovies + "')");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b7ba1ad5-3798-430a-b157-e447ea25beb9', N'dd613a84-fe75-40a4-9549-31747526d952')");
        }

        public override void Down()
        {
        }
    }
}
