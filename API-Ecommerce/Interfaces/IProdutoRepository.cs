namespace API_Ecommerce.Interfaces;
public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetProdutos();
    Task<Produto> GetProduto(int id);
    Task CreateProduto(Produto produto);
    Task UpdateProduto(Produto produto);
    Task DeleteProduto(int id);
}