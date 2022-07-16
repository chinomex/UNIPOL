using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
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

namespace UNIPOL.Reportes
{
    /// <summary>
    /// Lógica de interacción para Reporteador.xaml
    /// </summary>
    public partial class Reporteador : Window
    {
        public Reporteador(ReportDocument Reporte)
        {
            InitializeComponent();

            try
            {
                this.crReporteador.ReportSource = Reporte;
                this.crReporteador.Zoom(100);
                //this.crReporteador.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"UNIPOL", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public Reporteador(ReportDocument Reporte, int zoom)
        {
            InitializeComponent();

            try
            {
                this.crReporteador.ReportSource = Reporte;
                this.crReporteador.Zoom(zoom);
                //this.crReporteador.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
