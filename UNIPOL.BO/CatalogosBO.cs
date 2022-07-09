﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Classes;
using UNIPOL.DA;
using UNIPOL.EN.Catalogos;


namespace UNIPOL.BO
{
    public class CatalogosBO
    {
        CatalogosDA _da = null;
        public CatalogosBO()
        {
            _da = new CatalogosDA();
        }


        public Result<List<DatosUsuario>> ValidaUsuario(int idUsuario, string contra)
        {
            return _da.ValidaUsuario(idUsuario, contra);
        }

        public Result<List<DatosUsuario>> GuardarUsuario(int idUsuario, string nombre, string contra, bool esMedico, int tipo, string universidad, string cedula, string registroSSA)
        {
            return _da.GuardarUsuario(idUsuario, nombre, contra, esMedico, tipo, universidad, cedula, registroSSA);
        }

        public Result<List<DatosUsuario>> ConsultaUsuario(int idUsuario)
        {
            return _da.ConsultaUsuario(idUsuario);
        }

        public Result<List<DatosArticulo>> GuardarArticulo(int codArticulo, string descripcion, decimal precio, string estatus)
        {
            return _da.GuardarArticulo(codArticulo, descripcion, precio, estatus);
        }

        public Result<List<DatosArticulo>> ConsultaArticulo(int codArticulo)
        {
            return _da.ConsultaArticulo(codArticulo);

        }
    }
}
