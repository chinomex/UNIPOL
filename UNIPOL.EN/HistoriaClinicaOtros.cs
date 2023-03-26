using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class HistoriaClinicaOtros
    {
        public int IdHistoria { get; set; }
        public int IdInmunizacion { get; set; }
        public string Inmunizacion { get; set; }
        public string Religion { get; set; }
        public int IdGrupoSanguineo { get; set; }
        public string GrupooSanguineo { get; set; }
        public int IdFactor { get; set; }
        public string Factor { get; set; }
        public bool AlergicoPenicilina { get; set; }
        public string AlergicoPenicilinaTXT { get; set; }
        public string Otros { get; set; }
        public bool ETS { get; set; }
        public string ETSTXT { get; set; }
        public string EspecifiqueETS { get; set; }
        public bool SIDA { get; set; }
        public string SIDATXT { get; set; }
        public string Seropositivo { get; set; }
        public bool Drogas { get; set; }
        public string DrogasTXT { get; set; }
        public bool Cocaina { get; set; }
        public string CocainaTXT { get; set; }
        public bool Mariguana { get; set; }
        public string MariguanaTXT { get; set; }
        public string TiempoConsumo { get; set; }
        public bool Psicofarmacos { get; set; }
        public string PsicofarmacosTXT { get; set; }
        public bool IngestaAlcohol { get; set; }
        public string IngestaAlcoholTXT { get; set; }
        public bool Tabaquisto { get; set; }
        public string TabaquistoTXT { get; set; }
        public int IdCantidadTatuajes { get; set; }
        public string TatuajesDescripcion { get; set; }
        public string TatuajesLocalizacion { get; set; }
        public bool Deportes { get; set; }
        public string DeportesTXT { get; set; }
        public string DeportesPractica { get; set; }
        public bool TratamientoPsiquiatrico { get; set; }
        public string TratamientoPsiquiatricoTXT { get; set; }
        public bool TratamientoPsicologico { get; set; }
        public string TratamientoPsicologicoTXT { get; set; }
    }
}
