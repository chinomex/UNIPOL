using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Database;
using WarmPack.Classes;
using WarmPack.Extensions;
using UNIPOL.EN;
using System.Xml.Linq;
using System.Data;

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

        public Result<List<DatosPaciente>> GuardarPaciente(int codPaciente, string nombre, int idGenero, string domicilio, DateTime fechaNacimiento, string telefono, string correo, string rfc, string alergias)
        {
            var resultado = new Result<List<DatosPaciente>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodPaciente", ConexionDbType.Int, codPaciente);
                parametros.Add("@pNombre", ConexionDbType.VarChar, nombre);
                parametros.Add("@pIdGenero", ConexionDbType.Int, idGenero);
                parametros.Add("@pDomicilio", ConexionDbType.VarChar, domicilio);
                parametros.Add("@pFechaNacimiento", ConexionDbType.Date, fechaNacimiento.Date);
                parametros.Add("@pTelefono", ConexionDbType.VarChar, telefono);
                parametros.Add("@pCorreo", ConexionDbType.VarChar, correo);
                parametros.Add("@pRFC", ConexionDbType.VarChar, rfc);
                parametros.Add("@pAlergias", ConexionDbType.VarChar, alergias);
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


        public Result<int> GuardarReceta(int codPaciente, int codMedico, int pacienteTA, int pacienteFC, int pacienteFR, decimal pacienteTEM, string txtNotaEvolucion, List<ArticulosReceta> articulos)
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
                parametros.Add("@pNotaEvolucion", ConexionDbType.Decimal, txtNotaEvolucion);
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

        public Result<List<RecetaMedica>> RecetaHistorial(int CodPaciente)
        {
            var resultado = new Result<List<RecetaMedica>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodPaciente", ConexionDbType.Int, CodPaciente);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<RecetaMedica>("sp_RecetaHistorialCon", parametros);

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

        public Result<int> guardarHistoriaClinica(HC xml)
        {
            var resultado = new Result<int>();
            try
            {
                var sXML = xml.ToXml("historia");

                var parametros = new ConexionParameters();
                parametros.Add("@pXML", ConexionDbType.Xml, sXML);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 500);
                resultado = _conexion.ExecuteScalar<int>("sp_HistoriaClinicaGuardar", parametros);

                //resultado.Data.hc = _conexion.RecordsetsResults<HistoriaClinica>()?.First();
                //if(resultado.Data.hc != null)
                //{
                //    resultado.Data.hca = _conexion.RecordsetsResults<HistoriaClinicaAntecedentes>().First();
                //    resultado.Data.hco = _conexion.RecordsetsResults<HistoriaClinicaOtros>().First();
                //    resultado.Data.hcd = _conexion.RecordsetsResults<HistoriaClinicaDetras>().First();
                //}
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }


        public Result ConsultaHistoriaClinia(int idHistoria, ref DataSet ds)
        {
            var resultado = new Result();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@IdHistoria", ConexionDbType.Int, idHistoria);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults("sp_HistoriaClinicaCon", parametros, out ds);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }


        public Result<List<HistoriaClinicaHistoria>> ConsultaHistorial(int codPaciente, int codUsuario, DateTime fi, DateTime ff)
        {
            var resultado = new Result<List<HistoriaClinicaHistoria>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@codPaciente", ConexionDbType.Int, codPaciente);
                parametros.Add("@codUsuario", ConexionDbType.Int, codUsuario);
                parametros.Add("@fi", ConexionDbType.Date, fi);
                parametros.Add("@ff", ConexionDbType.Date, ff);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults< HistoriaClinicaHistoria>("sp_HistoriaClinicaHistorialCon", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }


        public Result<List<ConsultaMedicaHistoria>> ConsultaMedicaHistorial(int codPaciente, int codUsuario, DateTime fi, DateTime ff)
        {
            var resultado = new Result<List<ConsultaMedicaHistoria>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@codPaciente", ConexionDbType.Int, codPaciente);
                parametros.Add("@codUsuario", ConexionDbType.Int, codUsuario);
                parametros.Add("@fi", ConexionDbType.Date, fi);
                parametros.Add("@ff", ConexionDbType.Date, ff);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ConsultaMedicaHistoria>("sp_ConsultaMedicaHistorialCon", parametros);
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
