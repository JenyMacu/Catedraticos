using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Models
{
    public class CursooModel
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Display(Name = "Código de Curso")]
        public int CodigoCurso { get; set; }

        [Required(ErrorMessage = "El campo nombre curso es obligatorio")]                       
        [Column(TypeName ="varchar(40)")]  
        [Display(Name ="Nombre de Curso")]
        public string NombreCurso { get; set; }


        [Column(TypeName = "varchar(3)")]
        [Display(Name = "Estado de Curso")]
        public string EstadoCurso { get; set; } = "ACT";
     }
}
