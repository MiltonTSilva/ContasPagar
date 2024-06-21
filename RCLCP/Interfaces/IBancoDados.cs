using SQLite;

namespace RCLCP.Interfaces
{
    public interface IHasId
    {
        int Id { get; set; }
    }

    public interface IBancoDados
    {
        SQLiteAsyncConnection ConnectionDB<T>() where T : class, new();
        void CloseDatabase();
    }
}
