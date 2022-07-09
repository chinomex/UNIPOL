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

        private void txtUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void txtUsuario_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(txtUsuario.Text))
                {
                    var usuario = _bo.ConsultaUsuario(Convert.ToInt32(txtUsuario.Text));
                    if (usuario.Data.Count > 0)
                    {
                        var u = usuario.Data[0];
                        txtNombre.Text = u.Nombre;
                        txtPass.Password = u.Password;
                        txtPassConfirmacion.Password = u.Password;
                        ckMedico.IsChecked = u.esMedico;
                        if (u.esMedico)
                        {
                            cmbTipoMedico.SelectedIndex = u.Tipo;
                            txtUniversidad.Text = u.Universidad;
                            txtCedula.Text = u.Cedula;
                            txtSSA.Text = u.RegistroSSA;
                        }
                    }
                }

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
            if (!Convert.ToBoolean(ckMedico.IsChecked))
            {
                cmbTipoMedico.SelectedIndex = -1;
                txtUniversidad.Text = "";
                txtCedula.Text = "";
                txtSSA.Text = "";
            }
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
                var idUsusario = 0;
                if (!string.IsNullOrEmpty(txtUsuario.Text))
                {
                    idUsusario = Convert.ToInt32(txtUsuario.Text);
                }

                var r = _bo.GuardarUsuario(idUsusario, txtNombre.Text, txtPass.Password.ToString(), Convert.ToBoolean(ckMedico.IsChecked), cmbTipoMedico.SelectedIndex, txtUniversidad.Text, txtCedula.Text, txtSSA.Text);
                if (r.Value)
                {
                    if (r.Data.Count > 0)
                    {
                        txtUsuario.Text = r.Data[0].IdUsuario.ToString();
                    }
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

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Favor de escribir un nombre", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPass.Password.ToString()))
            {
                MessageBox.Show("Favor de escribir una contraseña", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtPass.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassConfirmacion.Password.ToString()))
            {
                MessageBox.Show("Favor de escribir la confirmacion de contraseña", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtPassConfirmacion.Focus();
                return false;
            }

            if (txtPass.Password.ToString() != txtPassConfirmacion.Password.ToString())
            {
                MessageBox.Show("La contrasela y la confirmacion no coniciden", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtPass.Focus();
                return false;
            }

            if (Convert.ToBoolean(ckMedico.IsChecked))
            {
                if (cmbTipoMedico.SelectedIndex < 0)
                {
                    MessageBox.Show("Favor de seleccionar el tipo de medico", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    cmbTipoMedico.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtUniversidad.Text))
                {
                    MessageBox.Show("Favor de escribir la universidad del medico", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtUniversidad.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtCedula.Text))
                {
                    MessageBox.Show("Favor de escribir la Cedula Profecional del medico", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtCedula.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtSSA.Text))
                {
                    MessageBox.Show("Favor de escribir el Registro SSA del medico", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtSSA.Focus();
                    return false;
                }
            }

            return true;
        }

        private void Limpiar()
        {
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtPass.Password = "";
            txtPassConfirmacion.Password = "";
            ckMedico.IsChecked = false;
            cmbTipoMedico.SelectedIndex = -1;
            txtUniversidad.Text = "";
            txtCedula.Text = "";
            txtSSA.Text = "";
        }
    }
}
