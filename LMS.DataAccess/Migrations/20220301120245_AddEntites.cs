using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.DataAccess.Migrations
{
    public partial class AddEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO [dbo].[LMSEntities] (Name, Description, Salary) VALUES('Test1', 'Test1', 10000 )");
            migrationBuilder.Sql($"INSERT INTO [dbo].[LMSEntities] (Name, Description, Salary) VALUES('Test2', 'Test2', 20000 )");
            migrationBuilder.Sql($"INSERT INTO [dbo].[LMSEntities] (Name, Description, Salary) VALUES('Test3', 'Test3', 30000 )");
            migrationBuilder.Sql($"INSERT INTO [dbo].[LMSEntities] (Name, Description, Salary) VALUES('Test4', 'Test4', 40000 )");
            migrationBuilder.Sql($"INSERT INTO [dbo].[LMSEntities] (Name, Description, Salary) VALUES('Test5', 'Test5', 50000 )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
