using System;
using System.Collections.Generic;

namespace CRUD_Factura_Encabezado.Models
{
    public partial class Encabezado
    {
        public int Id { get; set; }
        public string Factura { get; set; } = null!;
        public string Emisor { get; set; } = null!;
        public string FolioFiscal { get; set; } = null!;
        public DateTime FechaEmision { get; set; }
        public DateTime FechaCertificacion { get; set; }
        public string LugarExpedicion { get; set; } = null!;
        public int IdMetodoPago { get; set; }
        public int IdFormaPago { get; set; }
        public int IdMoneda { get; set; }
        public int IdEfectoComprobante { get; set; }

        public virtual EfectoComprobante IdEfectoComprobanteNavigation { get; set; } = null!;
        public virtual FormaPago IdFormaPagoNavigation { get; set; } = null!;
        public virtual MetodoPago IdMetodoPagoNavigation { get; set; } = null!;
        public virtual Moneda IdMonedaNavigation { get; set; } = null!;
    }
}
