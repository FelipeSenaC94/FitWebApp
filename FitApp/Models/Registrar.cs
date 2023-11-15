using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Models
{
    public class Registrar
    {
        public int RegistrarId { get; set; }
        public int Altura { get; set; }
        public double Peso { get; set; }
        public Usuario? Usuario { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
    }
}