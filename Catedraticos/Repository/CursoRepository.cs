using Catedraticos.Connection;
using Catedraticos.Models;
using Catedraticos.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Repository
{
    public class CursoRepository : iCursoRepository

    {
        private readonly Conn _db;

        public CursoRepository(Conn db) 
        {
            _db = db;
        }

        

        public bool ActualizarCatedratico(CursoModel curso)
        {
            _db.tbl_Cursos.Update(curso);
            return GuardarCurso();
        }

        

        public bool BorrarCursos(CursoModel curso)
        {
            _db.tbl_Cursos.Remove(curso);
            return GuardarCurso();
        }

       

        public bool CrearCurso(CursoModel curso)
        {
            _db.tbl_Cursos.Add(curso);
            return GuardarCurso();
        }
        public CursoModel GetCursos(int nCodigoCurso)
        {
            return _db.tbl_Cursos.FirstOrDefault(p => p.CodigoCurso == nCodigoCurso);
        }

        public ICollection<CursoModel> GetCursoModels()
        {
            return _db.tbl_Cursos.OrderBy(p => p.NombreCurso).ToList();
        }

}

        public bool GuardarCurso()
        {
            return _db.SaveChanges() >= 0 ? true : false;

        }

       
    }
}
