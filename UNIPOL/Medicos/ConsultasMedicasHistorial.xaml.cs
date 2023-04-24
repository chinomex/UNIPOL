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
using UNIPOL.EN;
using UNIPOL.General;

namespace UNIPOL.Medicos
{
    /// <summary>
    /// Lógica de interacción para ConsultasMedicasHistorial.xaml
    /// </summary>
    public partial class ConsultasMedicasHistorial : Window
    {
        ConsultasMedicasHistorialVM _vm = null;
        public ConsultasMedicasHistorial()
        {
            InitializeComponent();
            _vm = new ConsultasMedicasHistorialVM();
            this.DataContext = _vm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpFechaInicio.SelectedDate = DateTime.Today.AddDays(-7);
            dpFechaFin.SelectedDate = DateTime.Today;
            _vm.CargaHistorialConsultas(0, Globales.usuarioActivo.IdUsuario, dpFechaInicio.SelectedDate.Value, dpFechaFin.SelectedDate.Value);
        }

        private void piLimpiarPaciente_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _vm.pacienteCodigo = 0;
                _vm.pacienteNombre = "";
                _vm.CargaHistorialConsultas(0, Globales.usuarioActivo.IdUsuario, dpFechaInicio.SelectedDate.Value, dpFechaFin.SelectedDate.Value);
            }
            catch (Exception ex)
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
            catch(Exception ex)
            {

            }
        }

        private void btnConsultarHistorial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpFechaInicio.SelectedDate == null)
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
                    _vm.CargaHistorialConsultas(_vm.pacienteCodigo, 0, dpFechaInicio.SelectedDate.Value, dpFechaFin.SelectedDate.Value);
                }
                else
                {
                    _vm.CargaHistorialConsultas(0, Globales.usuarioActivo.IdUsuario, dpFechaInicio.SelectedDate.Value, dpFechaFin.SelectedDate.Value);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btnReimprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                _vm.ConsultaSeleccionada = btn.DataContext as ConsultaMedicaHistoria;
                if(_vm.ConsultaSeleccionada != null)
                {
                    _vm.ImprimirReceta();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("xx", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
