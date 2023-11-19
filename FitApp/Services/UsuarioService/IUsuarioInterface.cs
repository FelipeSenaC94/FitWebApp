using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitApp.Models;

namespace FitApp.Services.UsuarioService
{
    public interface IUsuarioInterface
    {
        Task<ServicesResponse<List<UsuarioModel>>> GetUsuarios();
        Task<ServicesResponse<List<UsuarioModel>>> CreateUsuarios(UsuarioModel novoUsuario);
        Task<ServicesResponse<UsuarioModel>> GetUsuarioById(int id);
        Task<ServicesResponse<List<UsuarioModel>>> UpdateUsuario(UsuarioModel editadoUsuario);
        Task<ServicesResponse<List<UsuarioModel>>> DeleteUsuario(int id);
        Task<ServicesResponse<List<UsuarioModel>>> InativaUsuario(int Id);
    }


}