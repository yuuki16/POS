using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_PointOfSale.Models
{
    public class Rol
    {
        [Key]
        public int rl_id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} and {1} caracteres", MinimumLength = 3)]
        public string rl_nombre { get; set; }

    }
}