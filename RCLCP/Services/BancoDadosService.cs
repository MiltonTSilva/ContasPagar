using RCLCP.Interfaces;
using SQLite;

namespace RCLCP.Services
{
    public class BancoDadosService : IBancoDados
    {

        private readonly string dbPathLocal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Agenda.db3");

        private SQLiteAsyncConnection? _dbConnection ;

        public SQLiteAsyncConnection ConnectionDB<T>() where T : class, new()
        {
            try
            {

                if (_dbConnection == null)
                {
                    _dbConnection = new SQLiteAsyncConnection(dbPathLocal,
                    SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
                    _dbConnection.ExecuteAsync("PRAGMA foreign_keys = ON;").Wait();
                }

                if (_dbConnection != null)
                {                   
                    _dbConnection.CreateTableAsync<T>().Wait();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (_dbConnection == null)
            {
                return new SQLiteAsyncConnection("");
            }

            return _dbConnection;

        }
    }
}