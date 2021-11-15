using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Catedraticos.Models.DTOs
{
    public class GuardarCursoDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Display(Name = "Código de Curso")]
        public int CodigoCurso { get; set; }
        public string NombreCurso { get; set; }


    }
}
