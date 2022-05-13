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

namespace UNIPOL.Medicos
{
    /// <summary>
    /// Lógica de interacción para AltaPaciente.xaml
    /// </summary>
    public partial class AltaPaciente : Window
    {
        public AltaPaciente()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtCodigo.Focus();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Guardar");
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtNombre.Focus();
            }
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtDomicilio.Focus();
            }
        }

        private void txtDomicilio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                dpFechaNacimiento.Focus();
            }
        }

        private void dpFechaNacimiento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtCorreo.Focus();
            }
        }

        private void txtCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnGuardar.Focus();
            }
        }
    }
}
