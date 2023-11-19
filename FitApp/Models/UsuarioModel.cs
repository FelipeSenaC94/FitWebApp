using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Models
{
    public class UsuarioModel
    {
        //definir como chave primária UserId
        [Key]
        //auto incrementar automaticamente 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int UserId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Sexo { get; set; }
        public bool? Logado { get; set; } = false;
        public bool Ativo { get; set; }
        
        // Lista de registros para entender relacionamento verificar Data/appdatacontext.cs  
        public List<RegistrarModel>? Registros { get; set; } = new List<RegistrarModel>(); 
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime? DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    }
}