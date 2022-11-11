using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaService _polizaService;
        public PolizaController(IPolizaService polizaService)
        {
            _polizaService = polizaService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] Poliza poliza)
        {
            try
            {
                poliza.FechaFin = poliza.FechaInicio.AddDays(365);
                poliza.VencimientoPoliza = poliza.FechaFin.AddDays(-1);
                var result = await _polizaService.SavedPolizaAsync(poliza);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListPoliza")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListPolizaAsync()
        {
            try
            {
                var listPoliza = await _polizaService.GetListPolizasAsync();
                return Ok(listPoliza);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{placaVehiculo}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(string placaVehiculo)
        {
            try
            {
                var poliza = await _polizaService.GetPolizaAsync(placaVehiculo);
                return Ok(poliza);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
