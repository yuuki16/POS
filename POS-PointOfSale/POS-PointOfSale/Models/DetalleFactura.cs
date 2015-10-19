using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_PointOfSale.Models
{
    public class DetalleFactura
    {
        [Key]
        public int df_detalleFacturaID { get; set; }
        public int df_factura { get; set; }
        public int df_numeroLinea { get; set; }
        public int df_codArticulo { get; set; }
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {1} and {2} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor en {0}")]
        public string df_descripcion { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Debe ingresar un valor en {0}")]
        public float df_cantidad { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Debe ingresar un valor en {0}")]
        public decimal df_precio { get; set; }
        public decimal df_subtotal { get; set; }

        public decimal df_total { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public float df_descuento { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Inventario Inventario { get; set; }
    }
}