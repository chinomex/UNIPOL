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

namespace UNIPOL.Inventarios
{
    /// <summary>
    /// Lógica de interacción para Existencias.xaml
    /// </summary>
    public partial class Existencias : Window
    {
        InventariosBO _bo = null;
        public Existencias()
        {
            _bo = new InventariosBO();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtCodigo.Focus();
        }

        private void txtCodigo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                dpCaducidad.Focus();
            }
        }

        private void txtCodigo_GotFocus(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void txtCodigo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                var r = _bo.ExistenciaArticulo(Convert.ToInt32(txtCodigo.Text));
                if (r.Value)
                {
                    if (r.Data.Count > 0)
                    {
                        var d = r.Data[0];
                        txtCodigo.Text = d.CodArticulo.ToString();
                        txtDescripcion.Text = d.Descripcion;
                        dpCaducidad.SelectedDate = d.Caducidad;
                        txtExistencia.Text = d.Existencia.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Articulo no encontrado", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void dpCaducidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtExistencia.Focus();
            }
        }
        private void txtExistencia_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtExistencia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnGuardar.Focus();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidaGuardar())
            {
                var r = _bo.ExistenciaGuardar(Convert.ToInt32(txtCodigo.Text), dpCaducidad.SelectedDate.Value, Convert.ToInt32(txtExistencia.Text));
                if (r.Value)
                {
                    txtCodigo.Focus();
                    MessageBox.Show("Existencia guardada correctamente", "UNIPOL", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show(r.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }




        private bool ValidaGuardar()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Favor de seleccionar un articulo", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtExistencia.Text))
            {
                MessageBox.Show("Favor de proporcionar una existencia", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                txtExistencia.Focus();
                return false;
            }

            if (Convert.ToInt32(txtExistencia.Text) <= 0)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("La existencia es correcta", "UNIPOL", System.Windows.MessageBoxButton.YesNo);

                if (result == MessageBoxResult.No)
                {
                    txtExistencia.Focus();
                    return false;
                }                
            }

            return true;
        }

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            dpCaducidad.SelectedDate = null;
            txtExistencia.Text = "";
        }
    }
}
