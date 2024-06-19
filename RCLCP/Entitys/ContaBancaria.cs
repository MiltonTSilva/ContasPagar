using SQLite;
using System.ComponentModel.DataAnnotations;

namespace RCLCP.Entitys
{

    [SQLite.Table("ContaBancaria")]
    public class ContaBancaria
    {
        [PrimaryKey, AutoIncrement]
        public int ContaBancariaId { get; set; }

        [Required(ErrorMessage = "O nome da Conta Bancaria é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        public bool Ativo { get; set; }
    }
}

