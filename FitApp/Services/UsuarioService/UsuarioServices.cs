using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using FitApp.Data;
using FitApp.Models;
using FitApp.Services.UsuarioService;
using Microsoft.EntityFrameworkCore;

namespace FitAppWeb.Services.UsuarioService
{
    public class UsuarioServices : IUsuarioInterface
    {
        private readonly AppDataContext _context;

        public UsuarioServices(AppDataContext context)
        {
            _context = context;
        }
        public async Task<ServicesResponse<List<UsuarioModel>>> CreateUsuarios(UsuarioModel Usuario)
        {
            ServicesResponse<List<UsuarioModel>> servicesResponse = new ServicesResponse<List<UsuarioModel>>();

            try
            {
                if (Usuario == null) 
                {
                    servicesResponse.Dados = null;
                    servicesResponse.Mensagem = "Informar dados";
                    servicesResponse.Sucesso = false;

                    return servicesResponse;
                }
               _context.Add(Usuario);
               await _context.SaveChangesAsync();
               servicesResponse.Dados = _context.Usuarios?.ToList();

            }catch(Exception ex)
            {
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
                
            }
            return servicesResponse;
        }

        public async Task<ServicesResponse<List<UsuarioModel>>> DeleteUsuario(int id)
        
        {
            ServicesResponse<List<UsuarioModel>> servicesResponse = new ServicesResponse<List<UsuarioModel>>();
            try
            {
                UsuarioModel usuario = _context.Usuarios.FirstOrDefault(x => x.UserId == id);
                if (usuario != null)
                {
                    // Handle the case where usuario is not null
                    _context.Usuarios.Remove(usuario);
                    await _context.SaveChangesAsync();
                    servicesResponse.Dados = _context.Usuarios.ToList();
                }
                else
                {
                    // Handle the case where usuario is null
                    servicesResponse.Dados = null;
                    servicesResponse.Mensagem = "Usuário não encontrado";
                    servicesResponse.Sucesso = false;
                }

            }
            catch (Exception ex)
            {
                

                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
                
            }
            return servicesResponse; 
        }

        public async Task<ServicesResponse<UsuarioModel>> GetUsuarioById(int id)
        {
            ServicesResponse<UsuarioModel> servicesResponse = new ServicesResponse<UsuarioModel>();
            
            try
            {
                UsuarioModel usuario = _context.Usuarios.FirstOrDefault(x => x.UserId == id);
                
                if (usuario == null)
                {
                    servicesResponse.Dados = null;
                    servicesResponse.Mensagem = "Usuário não encontrado";
                    servicesResponse.Sucesso = false;
                }
                
                servicesResponse.Dados = usuario;   
            }
            catch (Exception ex)
            {
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
            }
            return servicesResponse;

        }

        public async Task<ServicesResponse<List<UsuarioModel>>> GetUsuarios()
        {
            ServicesResponse<List<UsuarioModel>> servicesResponse = new ServicesResponse<List<UsuarioModel>>();
            try
            {
                servicesResponse.Dados = await Task.Run(() =>_context.Usuarios.ToList());
                if (servicesResponse.Dados.Count == 0) {
                    servicesResponse.Mensagem = "Nenhum dado encontrado";
                }
            }catch(Exception ex)
            {
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
            }
            return servicesResponse;
        }

        public async Task<ServicesResponse<List<UsuarioModel>>> InativaUsuario(int id )
        {
            ServicesResponse<List<UsuarioModel>> servicesResponse = new ServicesResponse<List<UsuarioModel>>();
           
            try
            {
                UsuarioModel usuario = _context.Usuarios.FirstOrDefault(x => x.UserId == id);
                if (usuario == null)
                {
                    servicesResponse.Dados = null;
                    servicesResponse.Mensagem = "Usuário não encontrado";
                    servicesResponse.Sucesso = false;
                }
                usuario.Ativo = false;
                usuario.DataAlteracao = DateTime.Now.ToLocalTime(); 
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                servicesResponse.Dados = _context.Usuarios.ToList();

            }catch (Exception ex)
            
            {
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;                
            }
            return servicesResponse;
        }

        public async Task<ServicesResponse<List<UsuarioModel>>> UpdateUsuario(UsuarioModel editadoUsuario)
        {
            ServicesResponse<List<UsuarioModel>> servicesResponse = new ServicesResponse<List<UsuarioModel>>();
            try
            {
                UsuarioModel usuario = _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.UserId == editadoUsuario.UserId);
                
                if (usuario == null)
                {
                    servicesResponse.Dados = null;
                    servicesResponse.Mensagem = "Usuário não encontrado";
                    servicesResponse.Sucesso = false;
                }   

                usuario.DataAlteracao = DateTime.Now.ToLocalTime();
                _context.Usuarios.Update(editadoUsuario);
                await _context.SaveChangesAsync();
                servicesResponse.Dados?.ToList();
                
            }
            catch (Exception ex)
            {
                
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
            }
            return servicesResponse;
        }
    }
}