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
        public int df_factura { get; set; }

        [Display(Name = "Numero de linea")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        public int df_numeroLinea { get; set; }

        [Display(Name = "Codigo de articulo")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        public int df_codArticulo { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float df_cantidad { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString="{0:C2}",ApplyFormatInEditMode = false)]
        public decimal df_precio { get; set; }

        [Display(Name = "Subtotal")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString="{0:C2}",ApplyFormatInEditMode = false)]
        public decimal df_subtotal { get; set; }

        [Display(Name = "Descuento")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString="{0:C2}",ApplyFormatInEditMode = false)]
        public decimal df_descuento { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString="{0:C2}",ApplyFormatInEditMode = false)]
        public decimal df_total { get; set; }
    }
}