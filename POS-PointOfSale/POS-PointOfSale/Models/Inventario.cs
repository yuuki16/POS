using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS_PointOfSale.Models
{
    public class Inventario
    {
        [Key]
        public int in_codArticulo { get; set; }
        
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} and {1} caracteres", MinimumLength = 3)]
        public string in_descripcion { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public float in_cantidad { get; set; }
        [Display(Name = "Costo")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString="{0:C2}", ApplyFormatInEditMode = false)]
        public decimal in_costo { get; set; }

        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal in_precio { get; set; }


        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }

}