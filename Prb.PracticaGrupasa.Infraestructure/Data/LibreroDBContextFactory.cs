using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Prb.PracticaGrupasa.Infraestructure.Data
{
    public class LibreroDBContextFactory: IDesignTimeDbContextFactory<LibreroDbContext>
    {
        public LibreroDbContext CreateDbContext(string[] args) 
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Prb.PracticaGrupasa");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
                .Build();

            var connectionsString = configuration.GetConnectionString("LibreroConnection");

            var optionsBuilder = new DbContextOptionsBuilder<LibreroDbContext>();
            optionsBuilder.UseSqlServer(connectionsString);

            return new LibreroDbContext(optionsBuilder.Options);
        }
    }
}
