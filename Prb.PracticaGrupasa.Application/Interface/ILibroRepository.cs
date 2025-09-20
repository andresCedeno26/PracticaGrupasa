using Prb.PracticaGrupasa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prb.PracticaGrupasa.Application.Interface
{
    public interface ILibroRepository
    {
        Task AddAsync(Libro libro);
        Task<IEnumerable<Libro>> GetAllAsync();
        Task UpdateAsync(Libro libro);
        Task DeleteAsync(Guid id);
        Task<Libro?> GetById(Guid id);
    }
}
