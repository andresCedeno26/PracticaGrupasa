using Microsoft.EntityFrameworkCore;
using Prb.PracticaGrupasa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prb.PracticaGrupasa.Infraestructure.Data
{
    public class LibreroDbContext:DbContext
    {
        public LibreroDbContext(DbContextOptions<LibreroDbContext> options):base(options) { }
        public DbSet<Libro> Libros { get; set; } = null;
    }
}
