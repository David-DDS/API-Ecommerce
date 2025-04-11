namespace API_Ecommerce.Interfaces;
public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> GetClientes();
    Task<Cliente> GetCliente(int id);
    Task CreateCliente(Cliente cliente);
    Task UpdateCliente(Cliente cliente);
    Task DeleteCliente(int id);
}