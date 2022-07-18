using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Database;
using WarmPack.Classes;
using UNIPOL.EN;

namespace UNIPOL.DA
{
    public class BusquedaDA
    {
        private readonly Conexion _conexion = null;

        public BusquedaDA()
        {
            try
            {
                _conexion = new Conexion(ConexionType.MSSQLServer, Globales.ConexionPrincipal);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Result<List<DatosBusqueda>> Busqueda(string txtBuscar, int tipoBusqueda)
        {
            var resultado = new Result<List<DatosBusqueda>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pBuscar", ConexionDbType.VarChar, txtBuscar);
                parametros.Add("@pTipoBusqueda", ConexionDbType.Int, tipoBusqueda);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<DatosBusqueda>("sp_PacientesCon", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }






    }
}
