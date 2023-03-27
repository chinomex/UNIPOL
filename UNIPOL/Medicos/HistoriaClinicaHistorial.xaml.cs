using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UNIPOL.BO;

namespace UNIPOL.Medicos
{
    /// <summary>
    /// Lógica de interacción para HistoriaClinicaHistorial.xaml
    /// </summary>
    public partial class HistoriaClinicaHistorial : Window
    {
        MedicosBO _bo = null;

        public HistoriaClinicaHistorial()
        {
            InitializeComponent();
            _bo = new MedicosBO();
        }

        private void btnReimprimir_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            var rHistoria = _bo.ConsultaHistoriaClinia(2, ref ds);
            if (rHistoria.Value)
            {
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "rptHistoriaClinica";
                    ds.Tables[1].TableName = "rptHistoriaClinicaAntecedentes";
                    ds.Tables[2].TableName = "rptHistoriaClinicaOtros";
                    ds.Tables[3].TableName = "rptHistoriaClinicaDetras";

                    ReportDocument reporte = new ReportDocument();
                    var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    reporte.Load(path + @"\Reportes\rptHistoriaClinica.rpt");
                    reporte.SetDataSource(ds);
                    Reportes.Reporteador reportView = new Reportes.Reporteador(reporte, 90);
                    reportView.WindowState = System.Windows.WindowState.Maximized;
                    reportView.Title = "Historia Clinica";
                    reportView.Show();
                }
            }
        }
    }
}
