using System;
using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Ecommerce.Repositories;
public class PagamentoRepository : IPagamentoRepository
{
    private readonly EcommerceContext _context;

    public PagamentoRepository(EcommerceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pagamento>> GetPagamentos()
    {
        return await _context.Pagamentos.ToListAsync();
    }

    public async Task<Pagamento> GetPagamento(int id)
    {
        return await _context.Pagamentos.FindAsync(id);
    }

    public async Task CreatePagamento(Pagamento pagamento)
    {
        _context.Pagamentos.Add(pagamento);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePagamento(Pagamento pagamento)
    {
        _context.Pagamentos.Update(pagamento);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePagamento(int id)
    {
        var pagamento = await _context.Pagamentos.FindAsync(id);
        if (pagamento != null)
        {
            _context.Pagamentos.Remove(pagamento);
            await _context.SaveChangesAsync();
        }
    }
}