using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Database;
using WarmPack.Classes;
using WarmPack.Extensions;
using UNIPOL.EN;


namespace UNIPOL.DA
{
    public class MedicosDA
    {
        private readonly Conexion _conexion = null;

        public MedicosDA()
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

        public Result<List<DatosPaciente>> ConsultaPaciente(int codPaciente)
        {
            var resultado = new Result<List<DatosPaciente>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodPaciente", ConexionDbType.Int, codPaciente);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<DatosPaciente>("sp_PacientesCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        public Result<List<DatosPaciente>> GuardarPaciente(int codPaciente, string nombre, string domicilio, DateTime fechaNacimiento, string telefono, string correo)
        {
            var resultado = new Result<List<DatosPaciente>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodPaciente", ConexionDbType.Int, codPaciente);
                parametros.Add("@pNombre", ConexionDbType.VarChar, nombre);
                parametros.Add("@pDomicilio", ConexionDbType.VarChar, domicilio);
                parametros.Add("@pFechaNacimiento", ConexionDbType.Date, fechaNacimiento.Date);
                parametros.Add("@pTelefono", ConexionDbType.VarChar, telefono);
                parametros.Add("@pCorreo", ConexionDbType.VarChar, correo);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<DatosPaciente>("sp_PacienteGuardar", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }


        public Result<int> GuardarReceta(int codPaciente, int codMedico, int pacienteTA, int pacienteFC, int pacienteFR, decimal pacienteTEM, List<ArticulosReceta> articulos)
        {
            var resultado = new Result<int>();
            var xml = articulos.ToXml("RecetaMedica");
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodPaciente", ConexionDbType.Int, codPaciente);
                parametros.Add("@pCodUsuario", ConexionDbType.Int, codMedico);
                parametros.Add("@pPacienteTA", ConexionDbType.Int, pacienteTA);
                parametros.Add("@pPacienteFC", ConexionDbType.Int, pacienteFC);
                parametros.Add("@pPacienteFR", ConexionDbType.Int, pacienteFR);
                parametros.Add("@pPacienteTEM", ConexionDbType.Decimal, pacienteTEM);
                parametros.Add("@pXmlDetalle", ConexionDbType.Xml, xml);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteScalar<int> ("sp_RecetaGuardar", parametros);                
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }


        public Result<List<RecetaMedica>> Receta(int idReceta)
        {
            var resultado = new Result<List<RecetaMedica>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pIdReceta", ConexionDbType.Int, idReceta);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<RecetaMedica>("sp_RecetaCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        public Result<int> UltimaReceta(int codMedico)
        {
            var resultado = new Result<int>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodUsuario", ConexionDbType.Int, codMedico);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteScalar<int>("sp_UltimaRecetaCon", parametros);
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
