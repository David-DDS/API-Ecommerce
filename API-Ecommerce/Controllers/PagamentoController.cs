using API_Ecommerce;
using API_Ecommerce.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class PagamentoController : ControllerBase
{
    private readonly IPagamentoRepository _pagamentoRepository;

    public PagamentoController(IPagamentoRepository pagamentoRepository)
    {
        _pagamentoRepository = pagamentoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamentos()
    {
        return Ok(await _pagamentoRepository.GetPagamentos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pagamento>> GetPagamento(int id)
    {
        var pagamento = await _pagamentoRepository.GetPagamento(id);
        if (pagamento == null)
        {
            return NotFound();
        }
        return Ok(pagamento);
    }

    [HttpPost]
    public async Task<ActionResult<Pagamento>> CreatePagamento(Pagamento pagamento)
    {
        await _pagamentoRepository.CreatePagamento(pagamento);
        return CreatedAtAction(nameof(GetPagamento), new { id = pagamento.IdPagamento }, pagamento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePagamento(int id, Pagamento pagamento)
    {
        if (id != pagamento.IdPagamento)
        {
            return BadRequest();
        }
        await _pagamentoRepository.UpdatePagamento(pagamento);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePagamento(int id)
    {
        var pagamento = await _pagamentoRepository.GetPagamento(id);
        if (pagamento == null)
        {
            return NotFound();
        }
        await _pagamentoRepository.DeletePagamento(id);
        return NoContent();
    }
}