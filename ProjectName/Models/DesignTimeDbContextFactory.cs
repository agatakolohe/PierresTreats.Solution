using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProjectName.Models TODO
{
    public class ProjectNameContextFactory : IDesignTimeDbContextFactory<ProjectNameContext> TODO
{

    ProjectNameContext IDesignTimeDbContextFactory<ProjectNameContext>.CreateDbContext(string[] args) TODO
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

    var builder = new DbContextOptionsBuilder<ProjectNameContext>(); TODO
    var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new ProjectNameContext(builder.Options); TODO
}
}
}