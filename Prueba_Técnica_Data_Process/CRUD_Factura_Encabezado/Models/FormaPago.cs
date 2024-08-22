using System;
using System.Collections.Generic;

namespace CRUD_Factura_Encabezado.Models
{
    public partial class FormaPago
    {
        public FormaPago()
        {
            Encabezado = new HashSet<Encabezado>();
        }

        public int IdFormaPago { get; set; }
        public string NombreFormaPago { get; set; } = null!;

        public virtual ICollection<Encabezado> Encabezado { get; set; }
    }
}
