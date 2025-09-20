using Microsoft.EntityFrameworkCore;
using Prb.PracticaGrupasa.Application.Interface;
using Prb.PracticaGrupasa.Domain.Entities;
using Prb.PracticaGrupasa.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prb.PracticaGrupasa.Infraestructure.Repositories
{
    public class LibroRepository:ILibroRepository
    {
        private readonly LibreroDbContext libreroDbContext;
        public LibroRepository(LibreroDbContext libreroDbContext)
        {
            this.libreroDbContext = libreroDbContext;
        }
        public async Task<Libro?> GetById(Guid id)
        {
            return await libreroDbContext.Libros.FirstOrDefaultAsync(l => l.id == id && l.Activo);
        }

        public async Task AddAsync(Libro libro)
        {
            await libreroDbContext.Libros.AddAsync(libro);
            await libreroDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Libro>> GetAllAsync()
        {
            return await libreroDbContext.Libros.AsNoTracking().ToListAsync();
        }
        public async Task UpdateAsync(Libro libro)
        {
            libreroDbContext.Libros.Update(libro);
            await libreroDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var libro = await libreroDbContext.Libros.FindAsync(id);
            if (libro != null)
            {
                libro.Activo = false;
                libreroDbContext.Libros.Update(libro);
                await libreroDbContext.SaveChangesAsync();
            }
        }
    }
}
