using RCLCP.Entitys;
using RCLCP.Interfaces;
using SQLite;

namespace RCLCP.Services
{
    public class UsuarioService : IUsuario
    {
        private SQLiteAsyncConnection? _dbConnection;
        private readonly IBancoDados bancoDadosService;

        public UsuarioService(IBancoDados bancoDadosService)
        {

            this.bancoDadosService = bancoDadosService;
            _dbConnection = this.bancoDadosService.ConnectionDB<Usuario>();

        }

        public async Task<bool> AddUsuarioAsync(Usuario? usuario)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.InsertAsync(usuario) > 0;
            }

            return retorno;
        }

        public async Task<bool> DeleteUsuarioAsync(Usuario? usuario)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.DeleteAsync(usuario) > 0;
            }

            return retorno;
        }

        public async Task<Usuario> GetUsuarioAsync(int id)
        {
            Usuario retorno = new();
            if (_dbConnection != null)
            {
                var table = _dbConnection.Table<Usuario>();
                retorno = await table.FirstOrDefaultAsync(c => c.UsuarioId == id);
            }

            return retorno;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            List<Usuario> retorno = [];
            if (_dbConnection != null)
            {
                var table = _dbConnection.Table<Usuario>();
                retorno = await table.OrderBy(o => o.Nome).ToListAsync();
            }

            return retorno;
        }

        public async Task<bool> UpdateUsuarioAsync(Usuario? usuario)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.UpdateAsync(usuario) > 0;
            }
            return retorno;
        }

    }
}
