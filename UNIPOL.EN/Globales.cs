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
        //public static string ConexionPrincipal = "data source = FUNCIÓNPOLICIAL; initial catalog = UNIPOLDB; user id = sa; password = UniPol2022";
        public static string ConexionPrincipal = "data source = 10.10.15.3; initial catalog = UNIPOLDB; user id = sa; password = UniPol2022";
        //public static string ConexionPrincipal = "data source = 192.168.233.1; initial catalog = UNIPOLDB; user id = sa; password = Dosmil14";

        public static DatosUsuario usuarioActivo { get; set; }
        public static bool UsuarioValido { get; set; }
    }   
}
