using System;
using System.Collections.Generic;

namespace CRUD_net2.models
{
    public partial class Sancione
    {
        public int Id { get; set; }
        public DateTime? FechaActual { get; set; }
        public int? ConductorId { get; set; }
        public string? Sancion { get; set; }
        public string? Observacion { get; set; }
        public decimal? Valor { get; set; }

        public virtual Conductor? Conductor { get; set; }
    }
}
