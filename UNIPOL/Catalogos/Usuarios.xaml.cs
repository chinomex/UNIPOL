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
using WarmPack.Classes;
using UNIPOL.BO;


namespace UNIPOL.Catalogos
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        CatalogosBO _bo = null;

        public Usuarios()
        {
            _bo = new CatalogosBO();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Focus();
            ckMedico.IsChecked = false;
            HabilitaDatosMedico(false);
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {                
                txtNombre.Focus();
            }
        }


        private void TxtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPass.Focus();
            }
        }

        private void TxtPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPassConfirmacion.Focus();
            }
        }

        private void TxtPassConfirmacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ckMedico.IsChecked.Value)
                {
                    cmbTipoMedico.Focus();
                }
                else
                {
                    btnGuardar.Focus();
                }
            }
        }

        private void cmbTipoMedico_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtUniversidad.Focus();
            }
        }

        private void txtUniversidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtCedula.Focus();
            }
        }

        private void txtCedula_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtSSA.Focus();
            }
        }

        private void txtSSA_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnGuardar.Focus();
            }
        }







        private void HabilitaDatosMedico(bool valor)
        {
            cmbTipoMedico.IsEnabled = valor;
            txtUniversidad.IsEnabled = valor;
            txtCedula.IsEnabled = valor;
            txtSSA.IsEnabled = valor;
        }

        private void ckMedico_Checked(object sender, RoutedEventArgs e)
        {
            HabilitaDatosMedico(ckMedico.IsChecked.Value);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidaGuardar())
            {
                var r = _bo.GuardarUsuario(Convert.ToInt32(txtUsuario.Text), txtNombre.Text, txtPass.Password.ToString(), Convert.ToBoolean(ckMedico.IsChecked), cmbTipoMedico.SelectedIndex, txtUniversidad.Text, txtCedula.Text, txtSSA.Text);
                if (r.Value)
                {
                    MessageBox.Show("Usuario guardado correctamente", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    MessageBox.Show(r.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }    
            }
        }


        private bool ValidaGuardar()
        {
            return false;
        }

    }
}
