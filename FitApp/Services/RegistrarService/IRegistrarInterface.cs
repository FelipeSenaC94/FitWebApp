using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitApp.Models;

namespace FitApp.Services.RegistrarService
{
    public interface IRegistrarInterface
    {
        Task<ServicesResponse<List<RegistrarModel>>> GetRegistros();
        Task<ServicesResponse<List<RegistrarModel>>> CreateRegistros(RegistrarModel novoRegistro);
        Task<ServicesResponse<RegistrarModel>> GetRegistroById(int id);
        Task<ServicesResponse<List<RegistrarModel>>> UpdateRegistro(RegistrarModel editadoRegistro);
        Task<ServicesResponse<List<RegistrarModel>>> DeleteRegistro(int id);
    }
}