using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UNIPOL.BO;
using WarmPack.Classes;

namespace UNIPOL.API.Modulos
{
    public class Autenticacion : NancyModule
    {
        private CatalogosBO _bo = null;

        public Autenticacion() : base("/catalogos")
        {
            _bo = new CatalogosBO();

            Post("/consulta-usuario", dato => PostConsultaUsuario(dato));

        }

        private object PostConsultaUsuario(dynamic arg)
        {
            try
            {
                return Response.AsJson("Ok");
            }
            catch (Exception ex)
            {
                return Response.AsJson(new Result(ex));
            }
        }


    }
}