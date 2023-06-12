using AdminPolizasAPI.Entidades;
using AdminPolizasAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdminPolizasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoberturaController : ControllerBase
    {
        private readonly ICoberturaService _coberturaService;
        private readonly ILogger<CoberturaController> _logger;

        public CoberturaController(ILogger<CoberturaController> logger, ICoberturaService coberturaService)
        {
            _logger = logger;
            _coberturaService = coberturaService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllCoberturas()
        {
            var response = await _coberturaService.GetAllCoberturas();
            return response.Count > 0 ? Ok(response) : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCobertura(int id)
        {
            var response = await _coberturaService.GetCobertura(id);
            return response == null ? BadRequest() : Ok(response);
        }

        [HttpPost()]
        public async Task<IActionResult> AddCobertura(CoberturaForAddDTO newCobertura)
        {
            var response = await _coberturaService.AddCobertura(newCobertura);
            return Ok(response);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateCobertura(CoberturaDTO coberturaForUpdate)
        {
            var response = await _coberturaService.UpdateCobertura(coberturaForUpdate);
            return response > 0 ? Ok(response) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobertura(int id)
        {
            var response = await _coberturaService.DeleteCobertura(id);
            return response ? Ok() : BadRequest();
        }
    }
}