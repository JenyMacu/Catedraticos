using Catedraticos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Repository.iRepository
{
    public interface iCursoRepository
    {
        ICollection<CursoModel> GetCursoModels(); 
        CursoModel GetCurso(int nCodigoCurso); 
        bool CrearCurso(CursoModel curso); 
        bool ActualizarCurso(CursoModel curso);
        bool BorrarCurso(CursoModel curso);
        bool GuardarCurso(); 

    }
}
