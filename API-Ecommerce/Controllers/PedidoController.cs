using API_Ecommerce;
using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoController(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
    {
        return Ok(await _pedidoRepository.GetPedidos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pedido>> GetPedido(int id)
    {
        var pedido = await _pedidoRepository.GetPedido(id);
        if (pedido == null)
        {
            return NotFound();
        }
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<ActionResult<Pedido>> CreatePedido(Pedido pedido)
    {
        await _pedidoRepository.CreatePedido(pedido);
        return CreatedAtAction(nameof(GetPedido), new { id = pedido.IdPedido }, pedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePedido(int id, Pedido pedido)
    {
        if (id != pedido.IdPedido)
        {
            return BadRequest();
        }
        await _pedidoRepository.UpdatePedido(pedido);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePedido(int id)
    {
        var pedido = await _pedidoRepository.GetPedido(id);
        if (pedido == null)
        {
            return NotFound();
        }
        await _pedidoRepository.DeletePedido(id);
        return NoContent();
    }
}