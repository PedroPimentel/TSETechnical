namespace TCE.Application.DTOs
{
    public class CompraDTO
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataCompra { get; set; }
        public string Descricao { get; set; }
        public decimal ValorPago { get; set; }
        public Guid IdempotencyKey { get; set; }
        public bool Pago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal ValorCompra { get; set; }
    }
}
