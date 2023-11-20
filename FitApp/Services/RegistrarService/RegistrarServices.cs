using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitApp.Data;
using FitApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitApp.Services.RegistrarService
{
    public class RegistrarServices : IRegistrarInterface
    {
        private readonly AppDataContext _context;

        public RegistrarServices(AppDataContext context)
        {
            _context = context;
        }
        public async Task<ServicesResponse<List<RegistrarModel>>> CreateRegistros(RegistrarModel Registros)
        {
            ServicesResponse<List<RegistrarModel>> servicesResponse = new ServicesResponse<List<RegistrarModel>>();

            try
            {
                if (Registros == null) 
                {
                    servicesResponse.Dados = null;
                    servicesResponse.Mensagem = "Informar dados";
                    servicesResponse.Sucesso = false;

                    return servicesResponse;
                }
               _context.Add(Registros);
               await _context.SaveChangesAsync();
               servicesResponse.Dados = _context.Registros?.ToList();

            }catch(Exception ex)
            {
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
                
            }
            return servicesResponse;
        }


        public async Task<ServicesResponse<List<RegistrarModel>>> GetRegistros()
        {
            ServicesResponse<List<RegistrarModel>> servicesResponse = new ServicesResponse<List<RegistrarModel>>();
            try
            {
                servicesResponse.Dados = await Task.Run(() =>_context.Registros.ToList());
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


        public async Task<ServicesResponse<List<RegistrarModel>>> DeleteRegistro(int id)
        
        {
            ServicesResponse<List<RegistrarModel>> servicesResponse = new ServicesResponse<List<RegistrarModel>>();
            try
            {
                RegistrarModel registro = _context.Registros.FirstOrDefault(x => x.RegistrarId == id);
                if (registro != null)
                {
                    // Handle the case where usuario is not null
                    _context.Registros.Remove(registro);
                    await _context.SaveChangesAsync();
                    servicesResponse.Dados = _context.Registros.ToList();
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

        public async Task<ServicesResponse<RegistrarModel>> GetRegistroByUserId(int id)
        {
            ServicesResponse<RegistrarModel> servicesResponse = new ServicesResponse<RegistrarModel>();
            
            try
            {
                RegistrarModel registro = _context.Registros.FirstOrDefault(x => x.UserId == id);
                
                if (registro == null)
                {
                    servicesResponse.Dados = null;
                    servicesResponse.Mensagem = "Usuário não encontrado";
                    servicesResponse.Sucesso = false;
                }
                
                servicesResponse.Dados = registro;   
            }
            catch (Exception ex)
            {
                servicesResponse.Mensagem = ex.Message;
                servicesResponse.Sucesso = false;
            }
            return servicesResponse;

        }
        public async Task<ServicesResponse<List<RegistrarModel>>> UpdateRegistro(RegistrarModel editadoRegistro)
        {
            ServicesResponse<List<RegistrarModel>> servicesResponse = new ServicesResponse<List<RegistrarModel>>();
            try
            {
                RegistrarModel registro = _context.Registros.AsNoTracking().FirstOrDefault(x => x.RegistrarId == editadoRegistro.RegistrarId);
                
                if (registro == null)
                {
                    servicesResponse.Dados = null;
                    servicesResponse.Mensagem = "Usuário não encontrado";
                    servicesResponse.Sucesso = false;
                }   

                registro.DataAlteracao = DateTime.Now.ToLocalTime();
                _context.Registros.Update(editadoRegistro);
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