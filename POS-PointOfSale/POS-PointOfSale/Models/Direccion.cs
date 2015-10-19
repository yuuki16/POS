using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_PointOfSale.Models
{
    public class Direccion
    {
        [Key]
        public int dr_id { get; set; }

        [Display(Name= "Provincia")]
        [Required(ErrorMessage= "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage= "El campo {0} de estar entre {2} y {1} caracteres", MinimumLength= 1)]
        public string dr_provincia { get; set; }

        [Display(Name = "Canton")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} de estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string dr_canton { get; set; }

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} de estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string dr_distrito { get; set; }

        [Display(Name = "Otras Señas")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} de estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string dr_otras { get; set; }

        [Display(Name = "Persona")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        public int dr_persona { get; set; }
    }
}