using AdminPolizasAPI.Entidades;
using AdminPolizasAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdminPolizasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolizasCoberturasController : ControllerBase
    {
        private readonly IPolizasCoberturasService _polizasCoberturasService;
        private readonly ILogger<PolizasCoberturasController> _logger;

        public PolizasCoberturasController(ILogger<PolizasCoberturasController> logger, IPolizasCoberturasService polizasCoberturasService)
        {
            _logger = logger;
            _polizasCoberturasService = polizasCoberturasService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllPolizasCoberturass()
        {
            var response = await _polizasCoberturasService.GetAllPolizasCoberturas();
            return response.Count > 0 ? Ok(response) : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolizasCoberturas(int id)
        {
            var response = await _polizasCoberturasService.GetPolizasCoberturas(id);
            return response == null ? BadRequest() : Ok(response);
        }

        [HttpPost()]
        public async Task<IActionResult> AddPolizasCoberturas(PolizasCoberturasForAddDTO newPolizasCoberturas)
        {
            var response = await _polizasCoberturasService.AddPolizasCoberturas(newPolizasCoberturas);
            return Ok(response);
        }

        [HttpPost("Detalle")]
        public async Task<IActionResult> AddPolizasCoberturasDetalle(PolizasCoberturasDetalleForAddDTO newPolizasCoberturasDetalle)
        {
            var response = await _polizasCoberturasService.AddPolizasCoberturasDetalle(newPolizasCoberturasDetalle);
            return Ok(response);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdatePolizasCoberturas(PolizasCoberturasDTO polizasCoberturasForUpdate)
        {
            var response = await _polizasCoberturasService.UpdatePolizasCoberturas(polizasCoberturasForUpdate);
            return response > 0 ? Ok(response) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolizasCoberturas(int id)
        {
            var response = await _polizasCoberturasService.DeletePolizasCoberturas(id);
            return response ? Ok() : BadRequest();
        }
    }
}