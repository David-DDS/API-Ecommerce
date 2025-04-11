using API_Ecommerce;
using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        return Ok(await _produtoRepository.GetProdutos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(int id)
    {
        var produto = await _produtoRepository.GetProduto(id);
        if (produto == null)
        {
            return NotFound();
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> CreateProduto(Produto produto)
    {
        await _produtoRepository.CreateProduto(produto);
        return CreatedAtAction(nameof(GetProduto), new { id = produto.IdProduto }, produto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduto(int id, Produto produto)
    {
        if (id != produto.IdProduto)
        {
            return BadRequest();
        }
        await _produtoRepository.UpdateProduto(produto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _produtoRepository.GetProduto(id);
        if (produto == null)
        {
            return NotFound();
        }
        await _produtoRepository.DeleteProduto(id);
        return NoContent();
    }
}