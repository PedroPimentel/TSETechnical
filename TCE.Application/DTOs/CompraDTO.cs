namespace TCE.Application.DTOs
{
    public class CompraDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataCompra { get; set; }
        public string Descricao { get; set; }
        public decimal ValorDevido { get; set; }
    }
}
