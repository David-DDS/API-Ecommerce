using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce;
using System;
using Microsoft.EntityFrameworkCore;
public class ProdutoRepository : IProdutoRepository
{
    private readonly EcommerceContext _context;

    public ProdutoRepository(EcommerceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> GetProdutos()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto> GetProduto(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task CreateProduto(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProduto(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto != null)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}