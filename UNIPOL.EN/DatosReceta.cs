using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class DatosReceta
    {
        public int IdReceta { get; set; }
        public int CodPaciente { get; set; }
        public string Paciente { get; set; }
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public string Universidad { get; set; }
        public string Cedula { get; set; }
        public string RegistroSSA { get; set; }
        public DateTime Fecha { get; set; }
    }
}
