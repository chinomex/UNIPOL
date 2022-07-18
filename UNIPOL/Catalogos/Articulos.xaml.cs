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

namespace UNIPOL.Catalogos
{
    /// <summary>
    /// Lógica de interacción para Articulos.xaml
    /// </summary>
    public partial class Articulos : Window
    {
        CatalogosBO _bo = null;
        public Articulos()
        {
            _bo = new CatalogosBO();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtCodigo.Focus();
        }

        private void txtCodigo_GotFocus(object sender, RoutedEventArgs e)
        {
            Limpiar();
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
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    var articulo = _bo.ConsultaArticulo(Convert.ToInt32(txtCodigo.Text));
                    if (articulo.Value)
                    {
                        if (articulo.Data.Count > 0)
                        {
                            var a = articulo.Data[0];
                            txtCodigo.Text = a.CodArticulo.ToString();
                            txtDescripcion.Text = a.Descripcion;
                            txtPrecio.Text = a.Precio.ToString("##,##0.00");
                            //Estatus = a.Estatus;
                        }
                        else
                        {
                            MessageBox.Show("Articulo no encontrado", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(articulo.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }

                }
                txtDescripcion.Focus();
            }
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPrecio.Focus();
            }
        }

        private void txtPrecio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Decimal || e.Key == Key.Back || e.Key == Key.OemPeriod)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtPrecio_KeyUp(object sender, KeyEventArgs e)
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
                var codArticulo = 0;
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    codArticulo = Convert.ToInt32(txtCodigo.Text);
                }

                var r = _bo.GuardarArticulo(codArticulo, txtDescripcion.Text, Convert.ToDecimal(txtPrecio.Text), "A");
                if (r.Value)
                {
                    if (r.Data.Count > 0)
                    {
                        txtCodigo.Text = r.Data[0].CodArticulo.ToString();
                        MessageBox.Show("Articulo guardado correctamente", "UNIPOL", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show(r.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }


        private bool ValidaGuardar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Favor de escribir la descripcion del articulo", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                txtDescripcion.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Favor de escribir el precio del articulo", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                txtPrecio.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtPrecio.Text) <= 0)
            {
                MessageBox.Show("Favor de escribir un precio del articulo valido", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                txtPrecio.Focus();
                return false;
            }

            return true;
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
    }
}
