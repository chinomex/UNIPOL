﻿using System;
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

        public Result<List<DatosUsuario>> GuardarUsuario(int idUsuario, string nombre, string contra, bool esMedico, int tipo, string universidad, string cedula, string registroSSA)
        {
            var resultado = new Result<List<DatosUsuario>>();
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
                resultado = _conexion.ExecuteWithResults<DatosUsuario>("sp_UsuariosGuardar", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        public Result<List<DatosUsuario>> ConsultaUsuario(int idUsuario)
        {
            var resultado = new Result<List<DatosUsuario>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pIdUsuario", ConexionDbType.Int, idUsuario);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<DatosUsuario>("sp_UsuarioCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }





        public Result<List<DatosArticulo>> GuardarArticulo(int codArticulo, string descripcion, decimal precio, string estatus)
        {
            var resultado = new Result<List<DatosArticulo>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodArticulo", ConexionDbType.Int, codArticulo);
                parametros.Add("@pDescripcion", ConexionDbType.VarChar, descripcion);
                parametros.Add("@pPrecio", ConexionDbType.Decimal, precio);
                parametros.Add("@pEstatus", ConexionDbType.VarChar, estatus);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<DatosArticulo>("sp_ArticulosGuardar", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }


        public Result<List<DatosArticulo>> ConsultaArticulo(int codArticulo)
        {
            var resultado = new Result<List<DatosArticulo>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodArticulo", ConexionDbType.Int, codArticulo);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<DatosArticulo>("sp_ArticulosCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }





        public Result<List<ComboGenerico>> ConsultaCatEstadoCivil()
        {
            var resultado = new Result<List<ComboGenerico>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ComboGenerico>("sp_CatEstadosCivilesCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        public Result<List<ComboGenerico>> ConsultaCatGenero()
        {
            var resultado = new Result<List<ComboGenerico>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ComboGenerico>("sp_CatGeneroCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        public Result<List<ComboGenerico>> ConsultaCatMPF()
        {
            var resultado = new Result<List<ComboGenerico>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ComboGenerico>("sp_CatMPFCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        public Result<List<ComboGenerico>> ConsultaCatInmunizaciones()
        {
            var resultado = new Result<List<ComboGenerico>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ComboGenerico>("sp_CatInmunizacionesCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        public Result<List<ComboGenerico>> ConsultaCatGrupoSanguineo()
        {
            var resultado = new Result<List<ComboGenerico>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ComboGenerico>("sp_CatGrupoSanguineoCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        public Result<List<ComboGenerico>> ConsultaCatFactor()
        {
            var resultado = new Result<List<ComboGenerico>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ComboGenerico>("sp_CatFactoresCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }


        public Result<List<ComboGenerico>> ConsultaCatTatuajes()
        {
            var resultado = new Result<List<ComboGenerico>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ComboGenerico>("sp_CatTatuajesCon", parametros);

            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        public Result<List<ComboGenerico>> ConsultaCatGenerico()
        {
            var resultado = new Result<List<ComboGenerico>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                resultado = _conexion.ExecuteWithResults<ComboGenerico>("sp_CatGenericoCon", parametros);

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
