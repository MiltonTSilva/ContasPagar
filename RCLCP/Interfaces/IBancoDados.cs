using SQLite;

namespace RCLCP.Interfaces
{
    public interface IHasId
    {
        int Id { get; set; }
    }

    public interface IBancoDados
    {
         public Task<SQLiteAsyncConnection> ConnectionDB<T>() where T : class, new();
    }
}
