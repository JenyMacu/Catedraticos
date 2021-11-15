using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Catedraticos.Models.DTOs
{
    public class GuardarCatedraticoDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Display(Name = "Código de Catedrático")]
        public int CodigoCatedratico { get; set; }
        public string NombreCatedratico { get; set; }

        public string ApellidoCatedratico { get; set; }

        public int EdadCatedratico { get; set; }
    }
}
