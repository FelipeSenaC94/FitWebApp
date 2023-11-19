using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitApp.Models;
using FitApp.Services.UsuarioService;

using Microsoft.AspNetCore.Mvc;

namespace FitAppWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface; 
        }
        [HttpGet]
        public async Task<ActionResult<ServicesResponse<List<UsuarioModel>>>> GetUsuarios()
        {
            return Ok( await _usuarioInterface.GetUsuarios());
        }
        
        [HttpGet("{id}")]   
        public async Task<ActionResult<ServicesResponse<UsuarioModel>>> GetUsuarioById(int id)
        {
            ServicesResponse<UsuarioModel> servicesResponse = await _usuarioInterface.GetUsuarioById(id);
            return Ok(servicesResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServicesResponse<List<UsuarioModel>>>> CreateUsuarios(UsuarioModel novoUsuario)
        {
            return Ok( await _usuarioInterface.CreateUsuarios(novoUsuario));
        }

        [HttpPut]
        public async Task<ActionResult<ServicesResponse<List<UsuarioModel>>>> UpdateUsuario(UsuarioModel editadoUsuario)
        {
            ServicesResponse<List<UsuarioModel>> servicesResponse = await _usuarioInterface.UpdateUsuario(editadoUsuario);
            return Ok(servicesResponse);
        }

        [HttpPut("inativaUsuario")]
        public async Task<ActionResult<ServicesResponse<List<UsuarioModel>>>> InativaUsuario(int id)
        {
            ServicesResponse<List<UsuarioModel>> servicesResponse = await _usuarioInterface.InativaUsuario(id);
            return Ok(servicesResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServicesResponse<List<UsuarioModel>>>> DeleteUsuario(int id)
        {
            ServicesResponse<List<UsuarioModel>> servicesResponse = await _usuarioInterface.DeleteUsuario(id);
            return Ok(servicesResponse);

        }

        
    }

}