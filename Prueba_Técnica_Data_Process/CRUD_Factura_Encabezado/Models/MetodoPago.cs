using System;
using System.Collections.Generic;

namespace CRUD_Factura_Encabezado.Models
{
    public partial class MetodoPago
    {
        public MetodoPago()
        {
            Encabezado = new HashSet<Encabezado>();
        }

        public int IdMetodoPago { get; set; }
        public string NombreMetodoPago { get; set; } = null!;

        public virtual ICollection<Encabezado> Encabezado { get; set; }
    }
}
