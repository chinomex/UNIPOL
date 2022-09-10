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
        public static string ConexionPrincipal = "data source = FUNCIÓNPOLICIAL; initial catalog = UNIPOLDB; user id = sa; password = UniPol2022";
        
        public static DatosUsuario usuarioActivo { get; set; }
    }   
}
