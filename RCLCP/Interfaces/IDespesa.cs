using RCLCP.Entitys;

namespace RCLCP.Interfaces
{
    public interface IDespesa
    {
        Task<List<Despesa>> GetDespesasAsync();
        Task<Despesa> GetDespesaAsync(int id);
        Task<bool> AddDespesaAsync(Despesa? despesa);
        Task<bool> UpdateDespesaAsync(Despesa? despesa);
        Task<bool> DeleteDespesaAsync(Despesa? despesa);
    }
}
