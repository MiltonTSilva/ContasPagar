using SQLite;
using System.ComponentModel.DataAnnotations;


namespace RCLCP.Entitys
{
    [SQLite.Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido.")]
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O e-mail não pode exceder 100 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O celular do usuário é obrigatório.")]
        public string Celular { get; set; } = string.Empty;

        //[DataType(DataType.Password)]
        //[StringLength(255, ErrorMessage = "Deve ter entre 5 e 255 caracteres", MinimumLength = 5)]   
        //[Required(ErrorMessage = "A senha do usuário é obrigatório.")]
        public string Senha { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Confirmação de senha é obrigatória")]
        //[StringLength(255, ErrorMessage = "Deve ter entre 5 e 255 caracteres", MinimumLength = 5)]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "As senhas não coincidem")]
        [Ignore]
        public string ConfirmaSenha { get; set; } = string.Empty;

        public bool Ativo { get; set; } 
    }
}
