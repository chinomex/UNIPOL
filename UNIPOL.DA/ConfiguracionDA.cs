using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Database;
using WarmPack.Classes;
using UNIPOL.EN;
using UNIPOL.EN.Configuracion;

namespace UNIPOL.DA
{
    public class ConfiguracionDA
    {
        private readonly Conexion _conexion = null;

        public ConfiguracionDA()
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

        public Result<List<DatosUsuario>> ValidaUsuaario(int idUsuario, string contra)
        {
            var resultado = new Result<List<DatosUsuario>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pIdUsuario", ConexionDbType.Int, idUsuario);
                parametros.Add("@pContra", ConexionDbType.VarChar, contra);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<DatosUsuario>("sp_ValidaUsario", parametros);

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
