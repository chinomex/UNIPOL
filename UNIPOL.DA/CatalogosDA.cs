using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Database;
using WarmPack.Classes;
using UNIPOL.EN;
using UNIPOL.EN.Catalogos;

namespace UNIPOL.DA
{
    public class CatalogosDA
    {
        private readonly Conexion _conexion = null;

        public CatalogosDA()
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

        public Result<List<DatosUsuario>> ValidaUsuario(int idUsuario, string contra)
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

        public Result GuardarUsuario(int idUsuario, string nombre, string contra, bool esMedico, int tipo, string universidad, string cedula, string registroSSA)
        {
            var resultado = new Result();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pIdUsuario", ConexionDbType.Int, idUsuario);
                parametros.Add("@pNombre", ConexionDbType.VarChar, nombre);
                parametros.Add("@pPassword", ConexionDbType.VarChar, contra);
                parametros.Add("@pEsMedico", ConexionDbType.Bit, esMedico);
                parametros.Add("@pTipo", ConexionDbType.Int, tipo);
                parametros.Add("@pUniversidad", ConexionDbType.VarChar, universidad);
                parametros.Add("@pCedula", ConexionDbType.VarChar, cedula);
                parametros.Add("@pRegistroSSA", ConexionDbType.VarChar, registroSSA);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.Execute("sp_UsuariosGuardar", parametros);
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
