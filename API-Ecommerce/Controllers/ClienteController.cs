using API_Ecommerce.Interfaces;
using API_Ecommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Ecommerce.Context;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        return Ok(await _clienteRepository.GetClientes());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _clienteRepository.GetCliente(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> CreateCliente(Cliente cliente)
    {
        await _clienteRepository.CreateCliente(cliente);
        return CreatedAtAction(nameof(GetCliente), new { id = cliente.IdCliente }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(int id, Cliente cliente)
    {
        if (id != cliente.IdCliente)
        {
            return BadRequest();
        }
        await _clienteRepository.UpdateCliente(cliente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _clienteRepository.GetCliente(id);
        if (cliente == null)
        {
            return NotFound();
        }
        await _clienteRepository.DeleteCliente(id);
        return NoContent();
    }
}