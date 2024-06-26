using RCLCP.Entitys;

namespace RCLCP.Interfaces
{
    public interface IPagamento
    {
        //Task InitializeAsync();
        Task<List<Pagamento>> GetPagamentosAsync();
        Task<Pagamento> GetPagamentoAsync(int id);
        Task<bool> AddPagamentoAsync(Pagamento? pagamento);
        Task<bool> UpdatePagamentoAsync(Pagamento? pagamento);
        Task<bool> DeletePagamentoAsync(Pagamento? pagamento);
        Task<List<Pagamento>> GetPagamentosComDespesaAsync();
        Task<Pagamento> GetPagamentoComDespesaAsync(int id);

    }
}
