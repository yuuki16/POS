using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_PointOfSale.Models
{
    public class Usuario
    {

        [Key]
        public int us_cedula { get; set; }

        [Display(Name= "Usuario")]
        [Required(ErrorMessage= "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage= "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength= 1)]
        public string us_usuario { get; set; }

        [Display(Name= "Contraseña")]
        [Required(ErrorMessage= "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage= "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength= 1)]
        public string us_clave { get; set; }

        [Display(Name= "Fecha de creacion")]
        [Required(ErrorMessage= "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString= "{0:yyyy/MM/dd}", ApplyFormatInEditMode= true)]
        [DataType(DataType.Date)]
        public DateTime us_fechaCreacion { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [StringLength(1, ErrorMessage = "El campo {0} debe contener {1} caracter(Y/N)", MinimumLength = 1)]
        public char us_activo { get; set; }

        [Display(Name = "Tipo de rol")]
        [Required(ErrorMessage = "Debe ingresar {0}")]
        public int us_tipoDeRol { get; set; }


    }
}