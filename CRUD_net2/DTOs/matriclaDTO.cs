namespace EF_02.DTOs
{
    public class matriclaDTO
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public DateTime? ValidaHasta { get; set; }
        public bool? Activo { get; set; }
    }
}
