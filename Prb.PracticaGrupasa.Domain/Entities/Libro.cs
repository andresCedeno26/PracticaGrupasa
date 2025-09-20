using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prb.PracticaGrupasa.Domain.Entities
{
    public class Libro
    {
        public Guid id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public bool Activo { get; set; }
        private Libro(){}
        public Libro(string titulo, string autor, int anio)
        {
            this.id = Guid.NewGuid();
            this.Titulo = titulo;
            this.Autor = autor;
            this.Anio = anio;
            this.Activo = true;
        }

        public void Inactivar() => this.Activo =false;
    }
}
