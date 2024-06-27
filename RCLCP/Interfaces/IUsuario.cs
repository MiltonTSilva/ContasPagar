using RCLCP.Entitys;

namespace RCLCP.Interfaces
{
    public interface IUsuario
    {
        Task<List<Usuario>> GetUsuariosAsync();
        Task<Usuario> GetUsuarioAsync(int id);
        Task<bool> AddUsuarioAsync(Usuario? usuario);
        Task<bool> UpdateUsuarioAsync(Usuario? usuario);
        Task<bool> DeleteUsuarioAsync(Usuario? usuario);
    }
}
