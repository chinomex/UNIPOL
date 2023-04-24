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
using UNIPOL.EN;
using UNIPOL.General;

namespace UNIPOL.Medicos
{
    /// <summary>
    /// Lógica de interacción para HistoriaClinicaHistorial.xaml
    /// </summary>
    public partial class HistoriaClinicaHistorial : Window
    {
        MedicosBO _bo = null;
        HistoriaClinicaHistorialVM _vm = null;
        public HistoriaClinicaHistorial()
        {
            _bo = new MedicosBO();
            InitializeComponent();
            _vm = new HistoriaClinicaHistorialVM();
            this.DataContext = _vm;
        }

        private void btnReimprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                _vm.HistoriaSeleccionada = btn.DataContext as HistoriaClinicaHistoria;

                if(_vm.HistoriaSeleccionada != null)
                {
                    DataSet ds = new DataSet();
                    var rHistoria = _bo.ConsultaHistoriaClinia(_vm.HistoriaSeleccionada.IdHistoria, ref ds);
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
                            //reporte.Load(path + @"\Reportes\rptHistoriaClinica.rpt");
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

        private void btnBuscarPaciente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Buscador buscador = new Buscador(1);
                buscador.Owner = this;
                buscador.ShowDialog();
                if (buscador.itemBusqueda != null && buscador.itemBusqueda.seleccionado)
                {
                    _vm.pacienteCodigo = buscador.itemBusqueda.Codigo;
                    _vm.pacienteNombre = buscador.itemBusqueda.Descripcion;
                    //_vm.CargaHistorial(_vm.pacienteCodigo, 0, dpFechaInicio.SelectedDate.Value, dpFechaFin.SelectedDate.Value);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpFechaInicio.SelectedDate = DateTime.Today.AddDays(-7);
            dpFechaFin.SelectedDate = DateTime.Today;
            _vm.CargaHistorial(0, Globales.usuarioActivo.IdUsuario, dpFechaInicio.SelectedDate.Value, dpFechaFin.SelectedDate.Value);
        }

        private void btnConsultarHistorias_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(dpFechaInicio.SelectedDate == null)
                {
                    dpFechaInicio.Focus();
                    MessageBox.Show("Favor de indicar la fecha de inicio.");
                    return;
                }

                if (dpFechaFin.SelectedDate == null)
                {
                    dpFechaFin.Focus();
                    MessageBox.Show("Favor de indicar la fecha de fin.");
                    return;
                }

                if (_vm.pacienteCodigo > 0)
                {
                    _vm.CargaHistorial(_vm.pacienteCodigo, 0, dpFechaInicio.SelectedDate.Value, dpFechaFin.SelectedDate.Value);
                }
                else
                {
                    _vm.CargaHistorial(0, Globales.usuarioActivo.IdUsuario, dpFechaInicio.SelectedDate.Value, dpFechaFin.SelectedDate.Value);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void piLimpiarPaciente_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _vm.pacienteCodigo = 0;
                _vm.pacienteNombre = "";
                _vm.CargaHistorial(0, Globales.usuarioActivo.IdUsuario, dpFechaInicio.SelectedDate.Value, dpFechaFin.SelectedDate.Value);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
