using Prb.PracticaGrupasa.Application.Interface;
using Prb.PracticaGrupasa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prb.PracticaGrupasa.Application.Services
{
    public class LibroService
    {
        private readonly ILibroRepository _libroRepository;
        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }
        public async Task RegistrarLibro(string titulo, string autor, int anio)
        {
            var libro = new Libro(titulo, autor, anio);
            await _libroRepository.AddAsync(libro);
        }

        public async Task<IEnumerable<Libro>> GetLibrosAsync()
        {
            return await _libroRepository.GetAllAsync();
        }

        public async Task<Libro?> GetById(Guid id)
        {
            return await _libroRepository.GetById(id);
        }

        public async Task UpdateAsync(Libro libro)
        {
            await _libroRepository.UpdateAsync(libro);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _libroRepository.DeleteAsync(id);
        }

    }
}
