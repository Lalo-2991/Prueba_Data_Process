using System;
using System.Collections.Generic;

namespace CRUD_Factura_Encabezado.Models
{
    public partial class Moneda
    {
        public Moneda()
        {
            Encabezado = new HashSet<Encabezado>();
        }

        public int IdMoneda { get; set; }
        public string NombreMoneda { get; set; } = null!;

        public virtual ICollection<Encabezado> Encabezado { get; set; }
    }
}
