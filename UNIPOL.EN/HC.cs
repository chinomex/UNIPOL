using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class HC
    {
        public HC()
        {
            hc = new HistoriaClinica();
            hca = new HistoriaClinicaAntecedentes();
            hco = new HistoriaClinicaOtros();
            hcd = new HistoriaClinicaDetras();
        }

        public HistoriaClinica hc { get; set; }
        public HistoriaClinicaAntecedentes hca { get; set; }
        public HistoriaClinicaOtros hco { get; set; }
        public HistoriaClinicaDetras hcd { get; set; }
    }
}
