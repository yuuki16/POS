using POS_PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_PointOfSale.ViewModels
{
    public class FacturaView
    {
        public Cliente Cliente { get; set; }
        public InventarioOrden Inventario { get; set; }
        public List<InventarioOrden> Inventarios { get; set; }
    }
}