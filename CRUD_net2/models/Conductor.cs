﻿using System;
using System.Collections.Generic;

namespace CRUD_net2.models
{
    public partial class Conductor
    {
        public int Id { get; set; }
        public string? Identificacion { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool? Activo { get; set; }
        public int? IdMatricula { get; set; }

        public virtual Matricula? IdMatriculaNavigation { get; set; }
    }
}
