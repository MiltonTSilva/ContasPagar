using RCLCP.Entitys;
using RCLCP.Interfaces;
using SQLite;



namespace RCLCP.Services
{
    public class FornecedorService : IFornecedor
    {
        private SQLiteAsyncConnection? _dbConnection;
        private readonly IBancoDados bancoDadosService;

        public FornecedorService(IBancoDados bancoDadosService)
        {

            this.bancoDadosService = bancoDadosService;
            _dbConnection = this.bancoDadosService.ConnectionDB<Fornecedor>();

        }


        public async Task<bool> AddFornecedorAsync(Fornecedor? fornecedor)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.InsertAsync(fornecedor) > 0;
            }

            return retorno;
        }

        public async Task<bool> DeleteFornecedorAsync(Fornecedor? fornecedor)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.DeleteAsync(fornecedor) > 0;
            }

            return retorno;
        }

        public async Task<Fornecedor> GetFornecedorAsync(int id)
        {
            Fornecedor retorno = new();
            if (_dbConnection != null)
            {
                var table = _dbConnection.Table<Fornecedor>();
                retorno = await table.FirstOrDefaultAsync(c => c.FornecedorId == id);
            }

            return retorno;
        }

        public async Task<List<Fornecedor>> GetFornecedoresAsync()
        {
            List<Fornecedor> retorno = [];
            if (_dbConnection != null)
            {
                var table = _dbConnection.Table<Fornecedor>();
                retorno = await table.ToListAsync();
            }

            return retorno;
        }


        public async Task<bool> UpdateFornecedorAsync(Fornecedor? fornecedor)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.UpdateAsync(fornecedor) > 0;
            }
            return retorno;
        }

    }
}
