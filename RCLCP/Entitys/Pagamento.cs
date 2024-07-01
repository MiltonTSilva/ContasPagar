using System.ComponentModel.DataAnnotations;
using SQLite;
using RCLCP.Enums;

namespace RCLCP.Entitys
{
    [SQLite.Table("Pagamentos")]
    public class Pagamento
    {
        [PrimaryKey, AutoIncrement]
        public int PagamentoId { get; set; }

        [Required(ErrorMessage = "Despesa é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, selecione uma despesa válida.")]
        public int DespesaId { get; set; }

        [Required(ErrorMessage = "Data de pagamento é obrigatório.")]
        public DateTime? DataPagamento { get; set; }

        [Required(ErrorMessage = "Valor a pagar é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor informe um valor válido")]
        public decimal ValorPagar { get; set; }

        public decimal ValorPago { get; set; }

        [Required(ErrorMessage = "Tipo de pagamento é obrigatório.")]
        public TipoPagamento TipoPagamento { get; set; }

        public bool DebitoAutomatico { get; set; }

        public bool EstaPago { get; set; }

        [Required(ErrorMessage = "Pagante é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, selecione um pagante válido.")]
        public int UsuarioPaganteId { get; set; }

        [Ignore]
        public Despesa? Despesa { get; set; }

        [Ignore]
        public Usuario? Usuario { get; set; }
    }
}
