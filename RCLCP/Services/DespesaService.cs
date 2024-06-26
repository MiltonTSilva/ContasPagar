using RCLCP.Entitys;
using RCLCP.Interfaces;
using SQLite;

namespace RCLCP.Services
{
    public class DespesaService : IDespesa
    {
        private SQLiteAsyncConnection? _dbConnection;
        private readonly IBancoDados bancoDadosService;

        public DespesaService(IBancoDados bancoDadosService)
        {

            this.bancoDadosService = bancoDadosService;
            _dbConnection = this.bancoDadosService.ConnectionDB<Despesa>();

        }

        public async Task<bool> AddDespesaAsync(Despesa? despesa)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.InsertAsync(despesa) > 0;
            }

            return retorno;
        }

        public async Task<bool> DeleteDespesaAsync(Despesa? despesa)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.DeleteAsync(despesa) > 0;
            }

            return retorno;
        }

        public async Task<Despesa> GetDespesaAsync(int id)
        {
            Despesa retorno = new();
            if (_dbConnection != null)
            {
                var table = _dbConnection.Table<Despesa>();
                retorno = await table.FirstOrDefaultAsync(c => c.DespesaId == id);
            }

            return retorno;
        }

        public async Task<List<Despesa>> GetDespesasAsync()
        {
            List<Despesa> retorno = [];
            if (_dbConnection != null)
            {
                var table = _dbConnection.Table<Despesa>();
                retorno = await table.OrderBy(o => o.Nome).ToListAsync();
            }

            return retorno;
        }

        public async Task<bool> UpdateDespesaAsync(Despesa? despesa)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.UpdateAsync(despesa) > 0;
            }
            return retorno;
        }

    }
}
