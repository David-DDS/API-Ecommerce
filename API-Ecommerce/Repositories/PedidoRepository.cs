using System;
using API_Ecommerce;
using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using Microsoft.EntityFrameworkCore;
public class PedidoRepository : IPedidoRepository
{
    private readonly EcommerceContext _context;

    public PedidoRepository(EcommerceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pedido>> GetPedidos()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<Pedido> GetPedido(int id)
    {
        return await _context.Pedidos.FindAsync(id);
    }

    public async Task CreatePedido(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePedido(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePedido(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}