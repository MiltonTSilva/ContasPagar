using RCLCP.Interfaces;
using SQLite;

namespace RCLCP.Services
{
    public class BancoDadosService : IBancoDados
    {

        private SQLiteAsyncConnection? _dbConnection;

        private string dbPathLocal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Agenda.db3");


        public async Task<SQLiteAsyncConnection> ConnectionDB<T>() where T : class, new()
        {
            try
            {

                if (_dbConnection == null)
                {
                    _dbConnection = new SQLiteAsyncConnection(dbPathLocal,
                    SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);

                }

                if (_dbConnection != null)
                {
                    _dbConnection.ExecuteAsync("PRAGMA foreign_keys = ON;").Wait();
                    _dbConnection.CreateTableAsync<T>().Wait();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            return _dbConnection;
        }
    }
}
