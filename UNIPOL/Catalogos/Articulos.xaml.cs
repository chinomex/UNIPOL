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

        private void txtCodigo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter)
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
                    if (articulo.Data.Count > 0)
                    {
                        var a = articulo.Data[0];
                        txtCodigo.Text = a.CodArticulo.ToString();
                        txtDescripcion.Text = a.Descripcion;
                        txtPrecio.Text = a.Precio.ToString("##,##0.00");
                        //Estatus = a.Estatus;
                    }
                }
                txtDescripcion.Focus();
            }
        }

        private void txtPrecio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
