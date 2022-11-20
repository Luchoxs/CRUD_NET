using System;
using System.Collections.Generic;

namespace CRUD_net2.models
{
    public partial class Matricula
    {
        public Matricula()
        {
            Conductors = new HashSet<Conductor>();
        }

        public int Id { get; set; }
        public string? Numero { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public DateTime? ValidaHasta { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Conductor> Conductors { get; set; }
    }
}
