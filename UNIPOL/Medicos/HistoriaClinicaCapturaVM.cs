using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UNIPOL.BO;
using UNIPOL.EN;

namespace UNIPOL.Medicos
{
    public class HistoriaClinicaCapturaVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        MedicosBO _bo = null;
        CatalogosBO _boCatalogos = null;
        public HistoriaClinicaCapturaVM()
        {
            _bo = new MedicosBO();
            _boCatalogos = new CatalogosBO();
            CargaListados();
        }

        //public int pacienteCodigo { get; set; }
        //public string pacienteNombre { get; set; }
        //public string pacienteFechaNacimiento { get; set; }
        //public string pacienteEdad { get; set; }
        //public string pacienteTelefono { get; set; }
        //public string pacienteSexo { get; set; }

        public DatosPaciente datosPaciente { get; set; }

        public List<ComboGenerico> lstEstadosCiviles { get; set; }
        public ComboGenerico EstadoCivilSeleccionado { get; set; }
        
        //public List<ComboGenerico> lstGenero { get; set; }
        //public ComboGenerico GeneroSeleccionado { get; set; }
        
        public List<ComboGenerico> lstInmunizaciones { get; set; }
        public ComboGenerico InmunizacionSeleccionado { get; set; }
        
        public List<ComboGenerico> lstMPF { get; set; }
        public ComboGenerico MPFSeleccionado { get; set; }
        
        public List<ComboGenerico> lstGrupoSanguineo { get; set; }
        public ComboGenerico GrupoSanguineoSeleccionado { get; set; }

        public List<ComboGenerico> lstFactor { get; set; }
        public ComboGenerico FactorSeleccionado { get; set; }

        public List<ComboGenerico> lstPenicilina { get; set; }
        public ComboGenerico PenicilinaSeleccionado { get; set; }

        public List<ComboGenerico> lstTransmisionSexual { get; set; }
        public ComboGenerico TransmisionSexualSeleccionado { get; set; }

        public List<ComboGenerico> lstSida { get; set; }
        public ComboGenerico SidaSeleccionado { get; set; }

        public List<ComboGenerico> lstDroga { get; set; }
        public ComboGenerico DrogaSeleccionado { get; set; }

        public List<ComboGenerico> lstCocaina { get; set; }
        public ComboGenerico CocainaSeleccionado { get; set; }

        public List<ComboGenerico> lstMariguana { get; set; }
        public ComboGenerico MariguanaSeleccionado { get; set; }

        public List<ComboGenerico> lstPsicofarmacos { get; set; }
        public ComboGenerico PsicofarmacosSeleccionado { get; set; }

        public List<ComboGenerico> lstTatuajes { get; set; }
        public ComboGenerico TatuajeSeleccionado { get; set; }

        public List<ComboGenerico> lstAlcohol { get; set; }
        public ComboGenerico AlcoholSeleccionado { get; set; }

        public List<ComboGenerico> lstTabaquismo { get; set; }
        public ComboGenerico TabaquismoSeleccionado { get; set; }

        public List<ComboGenerico> lstDeportes { get; set; }
        public ComboGenerico DeporteSeleccionado { get; set; }

        public List<ComboGenerico> lstPsiquiatrico { get; set; }
        public ComboGenerico PsiquiatricoSeleccionado { get; set; }

        public List<ComboGenerico> lstPsicologico { get; set; }
        public ComboGenerico PsicologicoSeleccionado { get; set; }


        public decimal Estatura { get; set; }
        public decimal Peso { get; set; }
        public decimal IMC { get; set; }
        public void ConsultaPaciente(int pacienteCodigo)
        {
            var r = _bo.ConsultaPaciente(pacienteCodigo);
            if(r.Value)
            {
                if (r.Data.Count > 0)
                {
                    datosPaciente = r.Data[0];
                }
                else
                {
                    datosPaciente = new DatosPaciente();
                }
                //pacienteFechaNacimiento = r.Data[0].FechaNacimiento.ToShortDateString();
                //pacienteEdad = r.Data[0].EdadCompleta;
                //pacienteTelefono = r.Data[0].Telefono;
                //pacienteSexo = r.Data[0].Genero;
            }
        }

        public void guardarHistoriaClinica(HC xml)
        {
            try
            {
                var r = _bo.guardarHistoriaClinica(xml);
                if(r.Value)
                {
                    DataSet ds = new DataSet();
                    var rHistoria = _bo.ConsultaHistoriaClinia(r.Data, ref ds);
                    if(rHistoria.Value)
                    {
                        if(ds.Tables.Count > 0)
                        {
                            ds.Tables[0].TableName = "rptHistoriaClinica";
                            ds.Tables[1].TableName = "rptHistoriaClinicaAntecedentes";
                            ds.Tables[2].TableName = "rptHistoriaClinicaOtros";
                            ds.Tables[3].TableName = "rptHistoriaClinicaDetras";

                            ReportDocument reporte = new ReportDocument();
                            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                            reporte.Load(path + @"\Reportes\rptHistoria.rpt");
                            reporte.SetDataSource(ds);
                            Reportes.Reporteador reportView = new Reportes.Reporteador(reporte, 90);
                            reportView.WindowState = System.Windows.WindowState.Maximized;
                            reportView.Title = "Historia Clinica";
                            reportView.Show();
                        }
                    }
                }

            }
            catch(Exception ex)
            {

            }
        }



        private void CargaListados()
        {

            lstEstadosCiviles = new List<ComboGenerico>();
            var rEstadoCivil = _boCatalogos.ConsultaCatEstadoCivil();
            if (rEstadoCivil.Value)
            {
                lstEstadosCiviles = rEstadoCivil.Data;
            }

        

            //lstGenero = new List<ComboGenerico>();
            //var rGenero = _boCatalogos.ConsultaCatGenero();
            //if (rGenero.Value)
            //{
            //    lstGenero = rGenero.Data;
            //}




            lstMPF = new List<ComboGenerico>();
            var rMPF = _boCatalogos.ConsultaCatMPF();
            if (rMPF.Value)
            {
                lstMPF = rMPF.Data;
            }

            lstInmunizaciones = new List<ComboGenerico>();
            var rInmunizaciones = _boCatalogos.ConsultaCatInmunizaciones();
            if (rInmunizaciones.Value)
            {
                lstInmunizaciones = rInmunizaciones.Data;
            }

            lstGrupoSanguineo = new List<ComboGenerico>();
            var rGrupoSanguineo = _boCatalogos.ConsultaCatGrupoSanguineo();
            if (rGrupoSanguineo.Value)
            {
                lstGrupoSanguineo = rGrupoSanguineo.Data;
            }


            lstFactor = new List<ComboGenerico>();
            var rFactor = _boCatalogos.ConsultaCatFactor();
            if (rFactor.Value)
            {
                lstFactor = rFactor.Data;
            }

            lstTatuajes = new List<ComboGenerico>();
            var rTatuajes = _boCatalogos.ConsultaCatTatuajes();
            if (rTatuajes.Value)
            {
                lstTatuajes = rTatuajes.Data;
            }

            ComboGenerico i = new ComboGenerico();
            lstPenicilina = new List<ComboGenerico>();
            lstTransmisionSexual = new List<ComboGenerico>();
            lstSida = new List<ComboGenerico>();
            lstDroga = new List<ComboGenerico>();
            lstCocaina = new List<ComboGenerico>();
            lstMariguana = new List<ComboGenerico>();
            lstPsicofarmacos = new List<ComboGenerico>();
            lstAlcohol = new List<ComboGenerico>();
            lstDeportes = new List<ComboGenerico>();
            lstTabaquismo = new List<ComboGenerico>();
            lstPsiquiatrico = new List<ComboGenerico>();
            lstPsicologico = new List<ComboGenerico>();
            var rGenericos = _boCatalogos.ConsultaCatGenerico();
            if (rGenericos.Value)
            {
                lstPenicilina = rGenericos.Data;
                lstTransmisionSexual = rGenericos.Data;
                lstSida = rGenericos.Data;
                lstDroga = rGenericos.Data;
                lstCocaina = rGenericos.Data;
                lstMariguana = rGenericos.Data;
                lstPsicofarmacos = rGenericos.Data;
                lstAlcohol = rGenericos.Data;
                lstDeportes = rGenericos.Data;
                lstTabaquismo = rGenericos.Data;
                lstPsiquiatrico = rGenericos.Data;
                lstPsicologico = rGenericos.Data;
            }



        }
    }
}
