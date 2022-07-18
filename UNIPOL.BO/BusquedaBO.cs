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
    public class BusquedaBO
    {
        BusquedaDA _da = null;
        public BusquedaBO()
        {
            _da = new BusquedaDA();
        }

        public Result<List<DatosBusqueda>> Busqueda(string txtBuscar, int tipoBusqueda)
        {
            return _da.Busqueda(txtBuscar, tipoBusqueda);
        }
    }
}
