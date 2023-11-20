using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitApp.Data;
using FitApp.Models;
using FitApp.Services.RegistrarService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FitApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrarController : ControllerBase
    {
        private readonly IRegistrarInterface _registrarInterface;

        public RegistrarController(IRegistrarInterface registrarInterface)
        {
            _registrarInterface = registrarInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ServicesResponse<List<RegistrarModel>>>> GetRegistros()
        {
            return Ok( await _registrarInterface.GetRegistros());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesResponse<List<RegistrarModel>>>> GetRegistroByUserId(int id)
        {
            return Ok( await _registrarInterface.GetRegistros());
        }
        
        [HttpPost]
        public async Task<ActionResult<ServicesResponse<List<RegistrarModel>>>> CreateRegistros(RegistrarModel novoRegistro)
        {
            return Ok( await _registrarInterface.CreateRegistros(novoRegistro));
        }
    }
}