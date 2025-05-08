using CRUDAPIs.Application.Interfaces;
using CRUDAPIs.Domain.Domain.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPIs.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class ComentariosController : ControllerBase
{
    private readonly IDBServices<Comentarios> _comentarioService;

    public ComentariosController(IDBServices<Comentarios> comentarioService)
    {
        _comentarioService = comentarioService;
    }

    // 🔍 Obtener todos los comentarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comentarios>>> GetComentarios()
    {
        return Ok(await _comentarioService.GetAllAsync());
    }

    // 🔍 Obtener comentario por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Comentarios>> GetComentarioById(int id)
    {
        var comentario = await _comentarioService.GetByIdAsync(id);
        return comentario != null ? Ok(comentario) : NotFound();
    }

    // ➕ Crear un nuevo comentario
    [HttpPost]
    public async Task<ActionResult> CreateComentario([FromBody] Comentarios comentario)
    {
        await _comentarioService.AddAsync(comentario);
        return CreatedAtAction(nameof(GetComentarioById), new { id = comentario.Id }, comentario);
    }

    // ✏️ Actualizar un comentario existente
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComentario(int id, [FromBody] Comentarios comentario)
    {
        if (id != comentario.Id) return BadRequest();
        await _comentarioService.UpdateAsync(comentario);
        return NoContent();
    }

    // ❌ Eliminar un comentario
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComentario(int id)
    {
        await _comentarioService.DeleteAsync(id);
        return NoContent();
    }
}