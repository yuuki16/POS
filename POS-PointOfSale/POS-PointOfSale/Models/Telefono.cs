using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_PointOfSale.Models
{
    public class Telefono
    {
        [Key]
        public int tl_id { get; set; }

        [Display(Name= "Telefono")]
        [Required(ErrorMessage= "Debe ingresar {0}")]
        public int tl_telefono { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} and {1} caracteres", MinimumLength = 3)]
        public string tl_tipo { get; set; }

        [Display(Name = "Persona")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        public int tl_persona { get; set; }

    }
}