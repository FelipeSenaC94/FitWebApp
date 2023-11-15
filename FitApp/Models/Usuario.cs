using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Models
{
    public class Usuario
    {
        public int UserId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Sexo { get; set; }
        public bool? Logado { get; set; } = false;
        public List<Registrar>? Registros { get; set; } = new List<Registrar>(); // Lista de registros   
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime? DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    }
}