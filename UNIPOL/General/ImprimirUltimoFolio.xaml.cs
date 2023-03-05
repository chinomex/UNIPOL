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
using UNIPOL.BO;
using UNIPOL.EN;

namespace UNIPOL.General
{
    /// <summary>
    /// Lógica de interacción para ImprimirUltimoFolio.xaml
    /// </summary>
    public partial class ImprimirUltimoFolio : Window
    {
        public string TipoImpresion { get; set; }

        MedicosBO _boMedicos = null;
        public ImprimirUltimoFolio()
        {
            _boMedicos = new MedicosBO();
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(this.TipoImpresion == "R")
            {
                var ultima = _boMedicos.UltimaReceta(Globales.usuarioActivo.IdUsuario);
                if (ultima.Value)
                {
                    txtUltimoFolio.Text = ultima.Data.ToString();
                }
            }

            txtUltimoFolio.Focus();
        }

        private void txtUltimoFolio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(txtUltimoFolio.Text))
                {
                    btnImprimir.Focus();
                }
            }
        }

        private void txtUltimoFolio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUltimoFolio.Text))
                {
                    var receta = _boMedicos.Receta(Convert.ToInt32(txtUltimoFolio.Text));
                    if (receta.Data.Count > 0)
                    {
                        var d = receta.Data;
                        ReportDocument reporte = new ReportDocument();
                        var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                        reporte.Load(path + @"\Reportes\rptReceta.rpt");
                        reporte.SetDataSource(d);
                        Reportes.Reporteador reportView = new Reportes.Reporteador(reporte, 90);
                        reportView.WindowState = System.Windows.WindowState.Maximized;
                        reportView.Title = "Receta";
                        reportView.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron resultados", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
