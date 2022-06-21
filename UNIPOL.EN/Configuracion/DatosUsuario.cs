using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN.Configuracion
{
    public class DatosUsuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public bool esMedico { get; set; }
        public int Tipo { get; set; }
        public string Universidad { get; set; }
        public string Cedula { get; set; }
        public string RegistroSSA { get; set; }
    }
}
