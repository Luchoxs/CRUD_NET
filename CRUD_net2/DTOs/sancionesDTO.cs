namespace EF_02.DTOs
{
    public class sancionesDTO
    {
        public int Id { get; set; }
        public DateTime? FechaActual { get; set; }
        public int? ConductorId { get; set; }
        public string? Sancion { get; set; }
        public string? Observacion { get; set; }
        public decimal? Valor { get; set; }
    }
}
