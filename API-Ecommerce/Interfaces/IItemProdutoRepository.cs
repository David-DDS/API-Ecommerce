namespace API_Ecommerce.Interfaces
{
    public interface IItemPedidoRepository
    {
        Task<IEnumerable<ItemPedido>> GetItemPedido();
        Task<ItemPedido> GetItemPedido(int id);
        Task CreateItemPedido(ItemPedido itemPedido);
        Task UpdateItemPedido(ItemPedido itemPedido);
        Task DeleteItemPedido(int id);
    }
}