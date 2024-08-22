using System;
using System.Collections.Generic;

namespace CRUD_Factura_Encabezado.Models
{
    public partial class EfectoComprobante
    {
        public EfectoComprobante()
        {
            Encabezado = new HashSet<Encabezado>();
        }

        public int IdEfectoComprobante { get; set; }
        public string NombreEfectoComprobante { get; set; } = null!;

        public virtual ICollection<Encabezado> Encabezado { get; set; }
    }
}
