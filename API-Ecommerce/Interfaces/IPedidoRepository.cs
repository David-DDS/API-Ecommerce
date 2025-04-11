namespace API_Ecommerce.Interfaces;
public interface IPedidoRepository
{
    Task<IEnumerable<Pedido>> GetPedidos();
    Task<Pedido> GetPedido(int id);
    Task CreatePedido(Pedido pedido);
    Task UpdatePedido(Pedido pedido);
    Task DeletePedido(int id);
}