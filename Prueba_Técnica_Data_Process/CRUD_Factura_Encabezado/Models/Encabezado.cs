using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Timers;

namespace CRUD_Factura_Encabezado.Models
{
    public partial class Encabezado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Factura es requerido")]
        [StringLength(10,MinimumLength =10, ErrorMessage = "La {0} debe contener 10 caracteres")]
        public string Factura { get; set; } = null!;

        [Required(ErrorMessage = "El Emisor es requerido")]
        public string Emisor { get; set; } = null!;

        [Required(ErrorMessage = "El Folio Fiscal es requerido")]
        [StringLength(32, MinimumLength = 32, ErrorMessage = "El Folio Fiscal debe estar conformado por 32 caracteres")]
        public string FolioFiscal { get; set; } = null!;

        [Required(ErrorMessage = "La Fecha de Emisión es requerida")]
        [DataType(DataType.DateTime, ErrorMessage ="La Fecha de Emisión es requerida")]
        public DateTime? FechaEmision { get; set; }

        [Required(ErrorMessage = "La Fecha de Certificación es requerida")]
        public DateTime? FechaCertificacion { get; set; }

        [Required(ErrorMessage = "El Código Postal es requerido")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "El Código postal solo debe contener 5 digitos")]
        public string LugarExpedicion { get; set; } = null!;

        [Required(ErrorMessage = "El Metodo de Pago es requerido")]
        public int? IdMetodoPago { get; set; }

        [Required(ErrorMessage = "La Forma de Pago es requerida")]
        public int? IdFormaPago { get; set; }
        
        [Required(ErrorMessage = "La  Moneda de Pago es requerida")]
        public int? IdMoneda { get; set; }

        [Required(ErrorMessage = "El Efecto de comprobante es requerido")]
        public int? IdEfectoComprobante { get; set; }

        public virtual EfectoComprobante IdEfectoComprobanteNavigation { get; set; } = null!;
        public virtual FormaPago IdFormaPagoNavigation { get; set; } = null!;
        public virtual MetodoPago IdMetodoPagoNavigation { get; set; } = null!;
        public virtual Moneda IdMonedaNavigation { get; set; } = null!;
    }
}
