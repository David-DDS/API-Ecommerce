using System;
using API_Ecommerce.Context;
using Microsoft.EntityFrameworkCore;

namespace API_Ecommerce.Repositories;
public class ItemPedidoRepository : Interfaces.IItemPedidoRepository
{
    private readonly EcommerceContext _context;

    public ItemPedidoRepository(EcommerceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ItemPedido>> GetItemPedido()
    {
        return await _context.ItemPedidos.ToListAsync();
    }

    public async Task<ItemPedido> GetItemPedido(int id)
    {
        return await _context.ItemPedidos.FindAsync(id);
    }

    public async Task CreateItemPedido(ItemPedido itemPedido)
    {
        _context.ItemPedidos.Add(itemPedido);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItemPedido(ItemPedido itemPedido)
    {
        _context.ItemPedidos.Update(itemPedido);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteItemPedido(int id)
    {
        var itemPedido = await _context.ItemPedidos.FindAsync(id);
        if (itemPedido != null)
        {
            _context.ItemPedidos.Remove(itemPedido);
            await _context.SaveChangesAsync();
        }
    }

    public Task<IEnumerable<ItemPedido>> GetItensPedido()
    {
        throw new NotImplementedException();
    }

    public Task<ItemPedido> GetItemPedidos(int id)
    {
        throw new NotImplementedException();
    }
}