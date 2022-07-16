using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIPOL.EN.Catalogos;

namespace UNIPOL.EN
{
    public class Globales
    {
        public static string ConexionPrincipal = "data source = HECTOR-PC; initial catalog = UNIPOLDB; user id = sa; password = Dosmil14";
        
        public static DatosUsuario usuarioActivo { get; set; }
    }   
}
