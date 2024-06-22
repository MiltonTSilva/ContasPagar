using RCLCP.Entitys;

namespace RCLCP.Interfaces
{
    public interface IFornecedor
    {
        //Task InitializeAsync();
        Task<List<Fornecedor>> GetFornecedoresAsync();
        Task<Fornecedor> GetFornecedorAsync(int id);
        Task<bool> AddFornecedorAsync(Fornecedor? fornecedor);
        Task<bool> UpdateFornecedorAsync(Fornecedor? fornecedor);
        Task<bool> DeleteFornecedorAsync(Fornecedor? fornecedor);


    }
}
