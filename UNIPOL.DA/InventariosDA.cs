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
    public class InventariosDA
    {
        private readonly Conexion _conexion = null;
        public InventariosDA()
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

        public Result<List<ArticuloExistencia>> ExistenciaArticulo(int codArticulo)
        {
            var resultado = new Result<List<ArticuloExistencia>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodArticulo", ConexionDbType.Int, codArticulo);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ArticuloExistencia>("sp_ExistenciaCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        public Result<List<ArticuloExistencia>> ExistenciaGuardar(int codArticulo, DateTime caducidad, int existencia)
        {
            var resultado = new Result<List<ArticuloExistencia>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodArticulo", ConexionDbType.Int, codArticulo);
                parametros.Add("@pCaducidad", ConexionDbType.Date, caducidad.Date);
                parametros.Add("@pExistencia", ConexionDbType.Int, existencia);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ArticuloExistencia>("sp_ExistenciaGuardar", parametros);

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
