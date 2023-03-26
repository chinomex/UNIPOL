using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class HistoriaClinica
    {
        public int IdHistoria { get; set; }
        public int CodPaciente { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string EdadCompleta { get; set; }
        public DateTime Fecha { get; set; }
        public string Modalidad { get; set; }
        public int IdEstatoCivil { get; set; }
        public string EstadoCivil { get; set; }
        public int IdGenero { get; set; }
        public string Genero { get; set; }
        public string SenasParticulares { get; set; }
        public string Escolaridad { get; set; }
        public string Originario { get; set; }
        public string Domicilio { get; set; }
        public string Procedencia { get; set; }
        public string Trabajo { get; set; }
        public string Telefono { get; set; }
    }
}
