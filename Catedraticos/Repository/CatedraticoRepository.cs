using Catedraticos.Connection;
using Catedraticos.Models;
using Catedraticos.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedraticos.Repository
{
    public class CatedraticoRepository : iCatedraticoRepository

    {
        private readonly Conn _db;

        public CatedraticoRepository(Conn db) 
        {
            _db = db;
        }

        

        public bool ActualizarCatedratico(CatedraticoModel catedratico)
        {
            _db.tbl_Catedratico.Update(catedratico);
            return GuardarCatedratico();
        }

       

        public bool BorrarCatedratico(CatedraticoModel catedratico)
        {
            _db.tbl_Catedratico.Remove(catedratico);
            return GuardarCatedratico();
        }

       

        public bool CrearCatedratico(CatedraticoModel catedratico)
        {
            _db.tbl_Catedratico.Add(catedratico);
            return GuardarCatedratico();
        }

      

        public CatedraticoModel GetCatedratico(int nCodigoCatedratico)
        {
            return _db.tbl_Catedratico.FirstOrDefault(p => p.CodigoCatedratico == nCodigoCatedratico);
        }

        public ICollection<CatedraticoModel> GetCatedraticoModels()
        {
            return _db.tbl_Catedratico.OrderBy(p => p.ApellidoCatedratico).ToList();
        }

       
        public bool GuardarCatedratico()
        {
            return _db.SaveChanges() >= 0 ? true : false;

        }
    }
}
