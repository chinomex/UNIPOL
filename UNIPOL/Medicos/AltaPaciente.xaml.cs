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
        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtNombre.Focus();
            }
        }

        private void txtCodigo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Back)
                e.Handled = false;
            else
                e.Handled = true;
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




        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Guardar");
        }


        private bool ValidaGuardar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Favor de escribir un nombre", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                txtNombre.Focus();
                return false;
            }

            return true;
        }



        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDomicilio.Text = "";
            dpFechaNacimiento.SelectedDate = null;
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }



    }
}
