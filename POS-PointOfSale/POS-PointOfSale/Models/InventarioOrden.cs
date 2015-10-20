using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_PointOfSale.Models
{
    public class InventarioOrden : Inventario
    {

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Debe ingresar un valor en {0}")]
        public float Cantidad { get; set; }

        public float Descuento { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal { get { return in_precio * (decimal)Cantidad ; } }


        public decimal Total { get { return SubTotal - ((SubTotal * (decimal)Descuento) / 100); } }
    }
}