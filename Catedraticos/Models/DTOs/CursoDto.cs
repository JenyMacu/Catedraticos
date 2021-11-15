using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catedraticos.Models.DTOs
{
    public class CursoDto
    {
        [Display(Name = "Nombre de curso")]
        public string NombreCurso { get; set; }
       
        
    }
}
