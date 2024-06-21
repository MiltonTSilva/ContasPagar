using RCLCP.Entitys;
using RCLCP.Interfaces;
using SQLite;



namespace RCLCP.Services
{
    public class ContaBancariaService : IContaBancaria
    {
        private SQLiteAsyncConnection? _dbConnection;
        private readonly IBancoDados bancoDadosService;

        public ContaBancariaService(IBancoDados bancoDadosService)
        {
            
            this.bancoDadosService = bancoDadosService;
            _dbConnection = this.bancoDadosService.ConnectionDB<ContaBancaria>();
        }


        public async Task<bool> AddContaBancariaAsync(ContaBancaria? contaBancaria)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.InsertAsync(contaBancaria) > 0;
            }

            return retorno;
        }

        public async Task<bool> DeleteContaBancariaAsync(ContaBancaria? contaBancaria)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.DeleteAsync(contaBancaria) > 0;
            }

            return retorno;
        }

        public async Task<ContaBancaria> GetContaBancariaAsync(int id)
        {
            ContaBancaria retorno = new();
            if (_dbConnection != null)
            {
                var table = _dbConnection.Table<ContaBancaria>();
                retorno = await table.FirstOrDefaultAsync(c => c.ContaBancariaId == id);
            }

            return retorno;
        }

        public async Task<List<ContaBancaria>> GetContasBancariasAsync()
        {
            List<ContaBancaria> retorno = [];
            if (_dbConnection != null)
            {
                var table = _dbConnection.Table<ContaBancaria>();
                retorno = await table.ToListAsync();
            }

            return retorno;
        }


        public async Task<bool> UpdateContaBancariaAsync(ContaBancaria? contaBancaria)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.UpdateAsync(contaBancaria) > 0;
            }
            return retorno;
        }

    }
}
