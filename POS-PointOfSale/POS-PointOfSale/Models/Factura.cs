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
        public int ft_numero { get; set;}

        [Display(Name= "Cliente")]
        [Required(ErrorMessage= "Debe ingresar {0}")]
        public int ft_cliente { get; set; }

        [Display(Name= "Fecha")]
        [Required(ErrorMessage="Debe ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode= true)]
        [DataType(DataType.Date)] 
        public DateTime ft_fecha { get; set; }

        [Display(Name= "Estampa")]
        [Required(ErrorMessage= "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString= "{0:yyyy/MM/dd}", ApplyFormatInEditMode= true)]
        [DataType(DataType.Date)]
        public DateTime ft_estampa { get; set; }

        [Display(Name= "Total")]
        [Required(ErrorMessage= "Debe ingresar {0}")]
        [DisplayFormat(DataFormatString= "{0:P2}", ApplyFormatInEditMode= false)]
        public decimal ft_total { get; set; }

        [Display(Name= "Estado")]
        [Required(ErrorMessage= "Debe ingresar {0}")]
        [StringLength(1, ErrorMessage= "El campo {0} debe contener {1} caracter(Y/N)", MinimumLength= 1)]
        public char ft_estado { get; set; }

        [Display(Name= "Empleado")]
        [Required(ErrorMessage= "Debe ingresar {0}")]
        public int ft_facturadoPor { get; set; }

    }
}