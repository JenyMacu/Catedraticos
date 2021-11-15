using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Catedraticos.Models
{
    public class CatedraticoModel
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Display(Name = "Código de Catedrático")]
        public int CodigoCatedratico { get; set; }

        [Required(ErrorMessage = "El campo nombre persona es obligatorio")]                       
        [Column(TypeName ="varchar(40)")]  
        [Display(Name ="Nombre de Catedrático")]
        public string NombreCatedrtico { get; set; }
        [Required(ErrorMessage = "El campo apellido Catedrático es obligatorio")]
        [Column(TypeName ="varchar(35)")]
        [Display(Name ="Apellido de Catedrático")]
        public string ApellidoCatedratico { get; set; }

        [Required(ErrorMessage = "El campo edad  es obligatorio")]
        [Column(TypeName = "int")]
        [Display(Name = "Edad de Catedratico")]
        public int EdadCatedratico { get; set; }

        [Column(TypeName = "varchar(3)")]
        [Display(Name = "Estado de Catedrático")]
        public string EstadoCatedratico { get; set; } = "ACT";
     }
}
