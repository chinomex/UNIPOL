using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIPOL.BO;
using UNIPOL.EN;

namespace UNIPOL.Medicos
{
    public class ConsultasMedicasHistorialVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        MedicosBO _bo = null;
        public ConsultasMedicasHistorialVM()
        {
            _bo = new MedicosBO();
        }

        public List<ConsultaMedicaHistoria> lstConsultas { get; set; }
        public ConsultaMedicaHistoria ConsultaSeleccionada { get; set; }
        public int pacienteCodigo { get; set; }
        public string pacienteNombre { get; set; }
        public int NoHistorias { get; set; }
        
        public void CargaHistorialConsultas(int codPaciente, int codUsuario, DateTime fi, DateTime ff)
        {
            var listado = _bo.ConsultaMedicaHistorial(codPaciente, codUsuario, fi, ff);
            lstConsultas = listado.Data;
            NoHistorias = listado.Data.Count;
        }

        public void ImprimirReceta()
        {
            try
            {
                var result = _bo.Receta(ConsultaSeleccionada.IdReceta);
                if (result.Data.Count > 0)
                {
                    var d = result.Data;
                    ReportDocument reporte = new ReportDocument();
                    var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    reporte.Load(path + @"\Reportes\rptReceta.rpt");
                    reporte.SetDataSource(d);
                    Reportes.Reporteador reportView = new Reportes.Reporteador(reporte, 90);
                    reportView.WindowState = System.Windows.WindowState.Maximized;
                    reportView.Title = "Receta";
                    reportView.Show();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
