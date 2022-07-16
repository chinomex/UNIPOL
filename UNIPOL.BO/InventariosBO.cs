using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Classes;
using UNIPOL.EN;
using UNIPOL.DA;

namespace UNIPOL.BO
{
    public class InventariosBO
    {
        InventariosDA _da = null;
        public InventariosBO()
        {
            _da = new InventariosDA();
        }

        public Result<List<ArticuloExistencia>> ExistenciaArticulo(int codArticulo)
        {
            return _da.ExistenciaArticulo(codArticulo);
        }

        public Result<List<ArticuloExistencia>> ExistenciaGuardar(int codArticulo, DateTime caducidad, int existencia)
        {
            return _da.ExistenciaGuardar(codArticulo, caducidad, existencia);
        }
    }
}
