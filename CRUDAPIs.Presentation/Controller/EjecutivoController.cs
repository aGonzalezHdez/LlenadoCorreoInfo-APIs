using CRUDAPIs.Application.Interfaces;
using CRUDAPIs.Domain.Domain.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPIs.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class EjecutivoController : ControllerBase
{
    private readonly IDBRepository<Ejecutivo> _ejecutivoService;

    public EjecutivoController(IDBRepository<Ejecutivo> ejecutivoService)
    {
        _ejecutivoService = ejecutivoService;
    }

    // 🔍 Obtener todos los ejecutivos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ejecutivo>>> GetEjecutivos()
    {
        return Ok(await _ejecutivoService.GetAllAsync());
    }

    // 🔍 Obtener ejecutivo por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Ejecutivo>> GetEjecutivoById(int id)
    {
        var ejecutivo = await _ejecutivoService.GetByIdAsync(id);
        return ejecutivo != null ? Ok(ejecutivo) : NotFound();
    }

    // ➕ Crear un nuevo ejecutivo
    [HttpPost]
    public async Task<ActionResult> CreateEjecutivo([FromBody] Ejecutivo ejecutivo)
    {
        await _ejecutivoService.AddAsync(ejecutivo);
        return CreatedAtAction(nameof(GetEjecutivoById), new { id = ejecutivo.Id }, ejecutivo);
    }

    // ✏️ Actualizar un ejecutivo existente
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEjecutivo(int id, [FromBody] Ejecutivo ejecutivo)
    {
        if (id != ejecutivo.Id) return BadRequest();
        await _ejecutivoService.UpdateAsync(ejecutivo);
        return NoContent();
    }

    // ❌ Eliminar un ejecutivo
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEjecutivo(int id)
    {
        await _ejecutivoService.DeleteAsync(id);
        return NoContent();
    }
}