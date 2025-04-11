namespace API_Ecommerce.Interfaces;
public interface IPagamentoRepository
{
    Task<IEnumerable<Pagamento>> GetPagamentos();
    Task<Pagamento> GetPagamento(int id);
    Task CreatePagamento(Pagamento pagamento);
    Task UpdatePagamento(Pagamento pagamento);
    Task DeletePagamento(int id);
}