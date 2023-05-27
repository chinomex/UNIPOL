using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UNIPOL.General;
using UNIPOL.EN;
using WarmPack.Classes;

namespace UNIPOL.Medicos
{
    /// <summary>
    /// Lógica de interacción para ConsultasMedicas.xaml
    /// </summary>
    public partial class ConsultasMedicas : Window
    {
        //List<ArticulosReceta> lstArticulos = null;

        ConsultasMedicasVM _vm = null;

        public ConsultasMedicas()
        {

            _vm = new ConsultasMedicasVM();
            this.DataContext = _vm;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnBuscarPaciente.Focus();
           
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidaAgregar())
            {
                _vm.AgregarMedicamento();
                btnBuscarMedicamento.Focus();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var result = _vm.guardar(txtTA.Text.Trim(), txtFC.Text.Trim(), txtFR.Text.Trim(), txtTEM.Text.Trim(), txtNotaEvolucion.Text.Trim());
            if (result.Value)
            {
                MessageBox.Show("Receta guardada correctamente.", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBuscarPaciente_Click(object sender, RoutedEventArgs e)
        {
            Buscador buscador = new Buscador(1);
            buscador.Owner = this;
            buscador.ShowDialog();
            if (buscador.itemBusqueda != null && buscador.itemBusqueda.seleccionado)
            {
                _vm.HistorialActivo = true;
                _vm.pacienteCodigo = buscador.itemBusqueda.Codigo;
                _vm.pacienteNombre = buscador.itemBusqueda.Descripcion;
            }
        }

        private void btnBuscarMedicamento_Click(object sender, RoutedEventArgs e)
        {
            Buscador buscador = new Buscador(2);
            buscador.Owner = this;
            buscador.ShowDialog();
            if (buscador.itemBusqueda != null && buscador.itemBusqueda.seleccionado)
            {
                _vm.medicamentoCodigo = buscador.itemBusqueda.Codigo;
                _vm.medicamentoDescripcion = buscador.itemBusqueda.Descripcion;
                txtCantidad.Focus();
            }
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtObservaciones.Focus();
            }
        }

        private void btnEliminaRenglon_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as ArticulosReceta;
            _vm.Articulos.Remove(item);
        }

        private void txtCantidad_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtObservaciones_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ValidaAgregar())
                {
                    _vm.AgregarMedicamento();
                }

                btnBuscarMedicamento.Focus();
            }
        }


        private bool ValidaAgregar()
        {
            if (_vm.pacienteCodigo == 0)
            {
                MessageBox.Show("Favor de seleccionar un paciente", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                btnBuscarPaciente.Focus();
                return false;
            }

            if (_vm.medicamentoCodigo == 0)
            {
                MessageBox.Show("Favor de seleccionar un medicamento", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                btnBuscarMedicamento.Focus();
                return false;
            }

            if (_vm.medicamentoCantidad <= 0)
            {
                MessageBox.Show("Favor de escribir una cantidad valida", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCantidad.Focus();
                return false;
            }

            return true;
        }

        private void txtTA_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Delete)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtFC_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Delete)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTEM_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9
                || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9
                || e.Key == Key.Enter
                || e.Key == Key.Decimal
                || e.Key == Key.Back
                || e.Key == Key.OemPeriod
                || e.Key == Key.Back
                || e.Key == Key.Delete
                || e.Key == Key.Left
                || e.Key == Key.Right)
            {
                if (e.Key != Key.Decimal)
                {
                    e.Handled = false;
                }
                else
                {
                    if(txtTEM.Text.IndexOf('.') <= 0)
                    {
                        e.Handled = false;
                    }   
                    else
                    {
                        e.Handled = true;
                    }
                    
                }
            }
            else
            {
                e.Handled = true;
            }
                
        }

        private void txtFR_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Delete)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTA_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtFC.Focus();
            }
        }

        private void txtFC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtFR.Focus();
            }
        }

        private void txtFR_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtTEM.Focus();
            }
        }

        private void txtTEM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnBuscarMedicamento.Focus();
            }
        }

        private void btnHistorial_Click(object sender, RoutedEventArgs e)
        {
            _vm.MuestraHistorial();
        }
    }
}
