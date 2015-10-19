using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_PointOfSale.Models
{
    public class Factura
    {

        [Key]
        public int ft_numero { get; set; }
        public int ft_Cliente { get; set; }
        public DateTime ft_fecha { get; set; }
        public TimeSpan ft_estampa { get; set; }
        public float ft_total { get; set; }
        public FacturaEstados FacturaEstados { get; set; }

        public virtual Cliente Cliente { get; set; }
        public ICollection<DetalleFactura> DetalleFactura { get; set; }

    }
}