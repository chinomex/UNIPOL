using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class DatosPaciente
    {
        public int CodPaciente { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public string EdadCompleta { get; set; }
    }
}
