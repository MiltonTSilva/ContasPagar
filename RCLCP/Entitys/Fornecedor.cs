using SQLite;
using System.ComponentModel.DataAnnotations;


namespace RCLCP.Entitys
{
    [SQLite.Table("Fornecedor")]
    public class Fornecedor
    {
        [PrimaryKey, AutoIncrement]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "O nome do fornecedor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        public bool Ativo { get; set; }
    }
}
