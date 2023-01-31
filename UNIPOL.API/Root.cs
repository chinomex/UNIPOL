using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UNIPOL.API
{
    public class Root : NancyModule
    {
        public Root()
        {
            Get("/", _ => GetRoot());
        }

        private object GetRoot()
        {
            var api = "API UNIPOL v-";
            var version = api + Assembly.GetExecutingAssembly().GetName().Version.ToString(); ;

            return Response.AsJson(version);
        }
    }
}