using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitApp.Data;
using FitApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FitApp.Controllers
{
    [ApiController]
    [Route("api/registrar")]
    public class RegistrarController : Controller
    {
        private readonly AppDataContext _context;

        public RegistrarController(AppDataContext context)
        {
            _context = context;
        }

               // GET: api/Registrar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registrar>>> GetRegistros()
        {
            // Obtém o ID do usuário a partir do token de autenticação
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Retorna todos os registros associados ao usuário logado
            return await _context.Registros.Where(r => r.UsuarioId == userId).ToListAsync();
        }

        // POST: api/Registrar
        [HttpPost]
        public async Task<ActionResult<Registrar>> CriarRegistro(Registrar registro)
        {
            // Obtém o ID do usuário a partir do token de autenticação
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Garante que o registro seja associado ao usuário correto
            if (registro.UsuarioId != userId)
            {
                return BadRequest("O ID do usuário no registro não corresponde ao usuário logado.");
            }

            _context.Registros.Add(registro);
            await _context.SaveChangesAsync();

            // Retorna um resultado Created com a URI completa do novo recurso
            return CreatedAtAction(nameof(ObterRegistroPorId), new { id = registro.RegistrarId }, registro);
        }

        // Método auxiliar para obter um registro por ID
        private bool RegistrarExists(int id)
        {
            return _context.Registros.Any(r => r.RegistrarId == id);
        }

        // Método auxiliar para obter um registro por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Registrar>> ObterRegistroPorId(int id)
        {
            var registro = await _context.Registros.FindAsync(id);

            if (registro == null)
            {
                return NotFound(); // Retorna um 404 Not Found se o registro não for encontrado
            }

            return registro;
        }
    }
}