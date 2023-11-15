using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FitApp.Data;
using FitApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FitApp.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDataContext _context;

        public UsuarioController(AppDataContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObterUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(); // Retorna um 404 Not Found se o usuário não for encontrado
            }

            return usuario;
        }
    
        [HttpPost]
        
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            try
            {
                // Gerar um salt aleatório (um valor único para cada usuário)
                byte[] salt = GenerateSalt();

                // Gerar o hash da senha com o salt
                string senhaHashed = HashPassword(usuario.Senha, salt);

                usuario.Senha = senhaHashed;

                _context.Add(usuario);
                _context.SaveChanges();

                // Retornar um resultado Created com a URI completa do novo recurso
                return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = usuario.UserId }, usuario);
            }
            catch (Exception e)
            {
                // Logar ou registrar a exceção para fins de diagnóstico
                Console.WriteLine($"Erro durante o cadastro: {e.Message}");
                return BadRequest("Erro durante o cadastro.");
            }
        }

         //------Sessão para criptografia de senha de usuário--------
    // Gera um salt aleatório
    public static byte[] GenerateSalt()
    {   
        byte[] salt = new byte[16];
        RandomNumberGenerator.Fill(salt);
        return salt;
    }

    // Gera o hash da senha usando o salt
    public static string HashPassword(string? senha, byte[] salt)
    {
        if (senha == null)
        {
            throw new ArgumentNullException(nameof(senha), "A senha não pode ser nula.");
        }

        using (var sha256 = SHA256.Create())
        {
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);
            byte[] senhaComSalt = new byte[senhaBytes.Length + salt.Length];

            for (int i = 0; i < senhaBytes.Length; i++)
            {
                senhaComSalt[i] = senhaBytes[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                senhaComSalt[senhaBytes.Length + i] = salt[i];
            }

            byte[] hashedPassword = sha256.ComputeHash(senhaComSalt);
            return Convert.ToBase64String(hashedPassword);
        }
    }

    // Verifica se uma senha fornecida corresponde ao hash armazenado
    public static bool VerifyPassword(string senha, byte[] salt, string hash)
    {
        string senhaHashed = HashPassword(senha, salt);
        return senhaHashed == hash;
    }
    //-------------------------FIM---------------------------
    }
    
}