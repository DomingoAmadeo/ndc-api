using AdminPolizasAPI.Entidades;
using AdminPolizasAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdminPolizasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaService _polizaService;
        private readonly ILogger<PolizaController> _logger;

        public PolizaController(ILogger<PolizaController> logger, IPolizaService polizaService)
        {
            _logger = logger;
            _polizaService = polizaService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllPolizas()
        {
            var response = await _polizaService.GetAllPolizas();
            return response.Count > 0 ? Ok(response) : BadRequest();
        }

        [HttpGet("Detalle/All")]
        public async Task<IActionResult> GetAllPolizaDetalle()
        {
            var response = await _polizaService.GetAllPolizaDetalle();
            return response.Count > 0 ? Ok(response) : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoliza(int id)
        {
            var response = await _polizaService.GetPoliza(id);
            return response == null ? BadRequest() : Ok(response);
        }

        [HttpPost()]
        public async Task<IActionResult> AddPoliza(PolizaForAddDTO newPoliza)
        {
            var response = await _polizaService.AddPoliza(newPoliza);
            return Ok(response);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdatePoliza(PolizaDTO polizaForUpdate)
        {
            var response = await _polizaService.UpdatePoliza(polizaForUpdate);
            return response > 0 ? Ok(response) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoliza(int id)
        {
            var response = await _polizaService.DeletePoliza(id);
            return response ? Ok() : BadRequest();
        }
    }
}