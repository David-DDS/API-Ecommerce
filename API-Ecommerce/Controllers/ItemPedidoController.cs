using API_Ecommerce;
using API_Ecommerce.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ItemPedidoController : ControllerBase
{
    private readonly IItemPedidoRepository _itemPedidoRepository;

    public ItemPedidoController(IItemPedidoRepository itemPedidoRepository)
    {
        _itemPedidoRepository = itemPedidoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemPedido>>> GetItensPedido()
    {
        return Ok(await _itemPedidoRepository.GetItemPedido());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemPedido>> GetItemPedido(int id)
    {
        var itemPedido = await _itemPedidoRepository.GetItemPedido(id);
        if (itemPedido == null)
        {
            return NotFound();
        }
        return Ok(itemPedido);
    }

    [HttpPost]
    public async Task<ActionResult<ItemPedido>> CreateItemPedido(ItemPedido itemPedido)
    {
        await _itemPedidoRepository.CreateItemPedido(itemPedido);
        return CreatedAtAction(nameof(GetItemPedido), new { id = itemPedido.IdItemPedido }, itemPedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItemPedido(int id, ItemPedido itemPedido)
    {
        if (id != itemPedido.IdItemPedido)
        {
            return BadRequest();
        }
        await _itemPedidoRepository.UpdateItemPedido(itemPedido);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItemPedido(int id)
    {
        var itemPedido = await _itemPedidoRepository.GetItemPedido(id);
        if (itemPedido == null)
        {
            return NotFound();
        }
        await _itemPedidoRepository.DeleteItemPedido(id);
        return NoContent();
    }
}