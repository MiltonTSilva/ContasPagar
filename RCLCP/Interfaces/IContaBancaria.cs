using RCLCP.Entitys;

namespace RCLCP.Interfaces
{
    public interface IContaBancaria
    {
        //Task InitializeAsync();
        Task<List<ContaBancaria>> GetContasBancariasAsync();
        Task<ContaBancaria> GetContaBancariaAsync(int id);
        Task<bool> AddContaBancariaAsync(ContaBancaria? contaBancaria);
        Task<bool> UpdateContaBancariaAsync(ContaBancaria? contaBancaria);
        Task<bool> DeleteContaBancariaAsync(ContaBancaria? contaBancaria);


    }
}
