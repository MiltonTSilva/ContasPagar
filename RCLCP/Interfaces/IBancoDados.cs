using SQLite;

namespace RCLCP.Interfaces
{
    public interface IHasId
    {
        int Id { get; set; }
    }

    public interface IBancoDados
    {
         public SQLiteAsyncConnection ConnectionDB<T>() where T : class, new();
    }
}
