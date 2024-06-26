using SQLite;
using System.ComponentModel.DataAnnotations;


namespace RCLCP.Entitys
{
    [SQLite.Table("Despesa")]
    public class Despesa
    {
        [PrimaryKey, AutoIncrement]
        public int DespesaId { get; set; }

        [Required(ErrorMessage = "O nome da despesa é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        public bool Ativo { get; set; }
    }
}
