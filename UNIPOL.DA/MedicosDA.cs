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


    }
}
