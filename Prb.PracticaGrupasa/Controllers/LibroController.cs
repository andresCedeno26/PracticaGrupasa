using Microsoft.AspNetCore.Mvc;
using Prb.PracticaGrupasa.Application.Services;
using Prb.PracticaGrupasa.Domain.Entities;

namespace Prb.PracticaGrupasa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly LibroService _libroService;
        public LibroController(LibroService libroService)
        {
            _libroService = libroService;
        }
        [HttpGet]
        public async Task<IEnumerable<Libro>> GetAll()
        {
            return await _libroService.GetLibrosAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LibroDto libroDto)
        {
            await _libroService.RegistrarLibro(libroDto.Titulo, libroDto.Autor, libroDto.Anio);
            return Ok("Libro registrado");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var libro = await _libroService.GetById(id);
            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Libro libro)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest();
            }
            await _libroService.UpdateAsync(libro);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest();
            }
            await _libroService.DeleteAsync(id);
            return NoContent();
        }
    }
}

public record LibroDto(string Titulo, string Autor, int Anio);