using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS_PointOfSale.Models
{
    public class Cliente
    {
        [Key]
        public int cl_cedula { get; set; }

        public DateTime cl_fechaCreacion { get; set; }

        public string cl_activo { get; set; }

        public int cl_direccion { get; set; }

        public int cl_tel { get; set; }
    }
}