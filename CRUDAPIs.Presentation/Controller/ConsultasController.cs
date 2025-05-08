using CRUDAPIs.Application.DTOs;
using CRUDAPIs.Application.Interfaces;
using CRUDAPIs.Domain.Domain.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPIs.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class ConsultasController : ControllerBase
{
    private readonly IConsultasService _consultasService;

    public ConsultasController(IConsultasService consultasService)
    {
        _consultasService = consultasService;
    }
    
    // 🔍 Obtener todos las consultas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConsultasDTO>>> GetConsultas()
    {
        return Ok(await _consultasService.ObtenerTodasConsultasAsync());
    }
    
    // 🔍 Obtener consultas por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ConsultasDTO>> GetConsultaById(int id)
    {
        var consulta = await _consultasService.ObtenetConsultaPorId(id);
        return consulta != null ? Ok(consulta) : NotFound();
    }
    
    // ➕ Crear una nueva consultas
    [HttpPost]
    public async Task<ActionResult> CreateConsulta([FromBody] ConsultasDTO consulta)
    {
        await _consultasService.AgregarConsultaAsync(consulta);
        return CreatedAtAction(nameof(GetConsultaById), new { id = consulta.Id }, consulta);
    }
    
    // ✏️ Actualizar una consulta existente
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateConsulta(int id, [FromBody] ConsultasDTO consulta)
    {
        if (id != consulta.Id) return BadRequest();
        await _consultasService.ActualizarConsultaAsync(consulta);
        return NoContent();
    }
    
    // ❌ Eliminar una consulta
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConsulta(int id)
    {
        await _consultasService.BorrarConsultaAsync(id);
        return NoContent();
    }
    
}