using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Classes;
using UNIPOL.DA;
using UNIPOL.EN.Configuracion;


namespace UNIPOL.BO
{
    public class ConfiguracionBO
    {
        ConfiguracionDA _da = null;
        public ConfiguracionBO()
        {
            _da = new ConfiguracionDA();
        }


        public Result<List<DatosUsuario>> ValidaUsuaario(int idUsuario, string contra)
        {
            return _da.ValidaUsuaario(idUsuario, contra);
        }
    }
}
