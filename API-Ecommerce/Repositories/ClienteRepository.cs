using System;
using API_Ecommerce;
using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ClienteRepository : IClienteRepository
{
    private readonly EcommerceContext _context;

    public ClienteRepository(EcommerceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> GetClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> GetCliente(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task CreateCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCliente(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}