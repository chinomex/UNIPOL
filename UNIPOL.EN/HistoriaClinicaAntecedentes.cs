using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class HistoriaClinicaAntecedentes
    {
        public int IdHistoria { get; set; }
        public string HeredoFamiliares { get; set; }
        public string PersonalesNoPatologicos { get; set; }
        public string AntecedentesCronicoDegenerativos { get; set; }
        public string AntecedentesQuirurgicos { get; set; }
        public string AntecedentesTraumatologicos { get; set; }
        public string Transfuciones { get; set; }
        public string Infectocontagiosos { get; set; }
        public string Hospitalizaiones { get; set; }
        public string COVID19 { get; set; }
        public int Menarca { get; set; }
        public int Embarazo { get; set; }
        public int Parto { get; set; }
        public int Cesarea { get; set; }
        public int Aborto { get; set; }
        public int IVSA { get; set; }
        public int IdMPF { get; set; }
        public DateTime FUN { get; set; }
        public string MPF { get; set; }
        public string UltimoPapanicolaoUltrasonido { get; set; }
        public string OtraObservacion { get; set; }
        public string PadecimientoActual { get; set; }

    }
}
