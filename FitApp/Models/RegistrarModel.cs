using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Models
{
    public class RegistrarModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int RegistrarId { get; set; }
        public int? Altura { get; set; }
        public double? Peso { get; set; }
        public int? UserId { get; set; }
        public DateTime? DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime? DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
    }
}