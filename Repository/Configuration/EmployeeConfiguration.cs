using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("fce0e256-1660-4048-a703-faa73353b726"),
                    Name = "Ahmed Mohamed",
                    Age = 24,
                    Position = "Software Developer",
                    CompanyId = new Guid("c9d4c053-49b6-410c-938c-2d54a9991870"),
                },
                new Employee
                {
                    Id = new Guid("c8cea98b-118a-47d4-b0f8-5fcdfe4d9aef"),
                    Name = "Chandler Bing",
                    Age = 35,
                    Position = "data configuration",
                    CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")

                });
        }
    }
}
