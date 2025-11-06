using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Context;

public class EmployeeHandbookDbContextFactory : IDesignTimeDbContextFactory<EmployeeHandbookContext>

{
    public EmployeeHandbookContext CreateDbContext(string[] args)

    {
        var optionsBuilder = new DbContextOptionsBuilder<EmployeeHandbookContext>();

        optionsBuilder.UseSqlServer();

        return new EmployeeHandbookContext(optionsBuilder.Options);
    }
}