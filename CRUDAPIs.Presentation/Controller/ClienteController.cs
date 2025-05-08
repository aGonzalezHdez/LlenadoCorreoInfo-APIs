using CRUDAPIs.Application.Interfaces;
using CRUDAPIs.Domain.Domain.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPIs.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IDBRepository<Cliente> _clienteService;

    public ClienteController(IDBRepository<Cliente> clienteService)
    {
        _clienteService = clienteService;
    }

    // 🔍 Obtener todos los clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        return Ok(await _clienteService.GetAllAsync());
    }

    // 🔍 Obtener cliente por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetClienteById(int id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        return cliente != null ? Ok(cliente) : NotFound();
    }

    // ➕ Crear un nuevo cliente
    [HttpPost]
    public async Task<ActionResult> CreateCliente([FromBody] Cliente cliente)
    {
        await _clienteService.AddAsync(cliente);
        return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
    }

    // ✏️ Actualizar un cliente existente
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(int id, [FromBody] Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest();
        await _clienteService.UpdateAsync(cliente);
        return NoContent();
    }

    // ❌ Eliminar un cliente
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        await _clienteService.DeleteAsync(id);
        return NoContent();
    }

}