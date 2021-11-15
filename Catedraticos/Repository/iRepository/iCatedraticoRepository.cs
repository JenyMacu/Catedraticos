using Catedraticos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedraticos.Repository.iRepository
{
    public interface iCatedraticoRepository
    {
        ICollection<CatedraticoModel> GetCatedraticoModels(); 
        CatedraticoModel GetCatedratico(int nCodigoCatedratico); 
        bool CrearCatedratico(CatedraticoModel catedratico); 
        bool ActualizarCatedratico(CatedraticoModel catedratico);
        bool BorrarCatedratico(CatedraticoModel catedratico);
        bool GuardarCatedratico(); 

    }
}
