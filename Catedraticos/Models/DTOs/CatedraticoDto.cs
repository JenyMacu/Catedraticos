using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catedraticos.Models.DTOs
{
    public class CatedraticoDto
    {
        [Display(Name = "Nombre de Catedrático")]
        public string NombreCatedratico { get; set; }
       
        [Display(Name = "Apellido de Catedrático")]
        public string ApellidoCatedratico { get; set; }

        [Display(Name = "Edad de catedrático")]
        public int EdadCatedratico { get; set; }
    }
}
