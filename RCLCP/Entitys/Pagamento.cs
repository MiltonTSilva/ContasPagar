using SQLite;
using System.ComponentModel.DataAnnotations;

namespace RCLCP.Entitys
{
    [SQLite.Table("Pagamentos")]
    public class Pagamento
    {
        [PrimaryKey, AutoIncrement]
        public int PagamentoId { get; set; }

        [Required(ErrorMessage = "Fornecedor é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, selecione um fornecedor válido")]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "Data de pagamento é obrigatório.")]
        public DateTime? DataPagamento { get; set; }

        [Required(ErrorMessage = "Valor a pagar é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor informe um valor válido")]
        public decimal ValorPagar { get; set; }

        public decimal ValorPago { get; set; }

        public bool DebitoAutomatico { get; set; }

        public bool EstaPago { get; set; }

        [Ignore]
        public Fornecedor? Fornecedor { get; set; }
    }
}
