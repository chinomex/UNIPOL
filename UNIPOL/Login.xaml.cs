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
using UNIPOL.EN.Catalogos;
using UNIPOL.EN;
using System.Data.SqlClient;

namespace UNIPOL
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        CatalogosBO _bo = null;

        //public bool usuarioValido { get; set; }

        public Login()
        {
            //usuarioValido = false;
            Globales.UsuarioValido = false;
            _bo = new CatalogosBO();
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Focus();
            //try
            //{ 
            //    MessageBox.Show( Globales.ConexionPrincipal, "UNIPOL");
            //    SqlConnection cnn = new SqlConnection(Globales.ConexionPrincipal);
            //    cnn.Open();

            //    MessageBox.Show(cnn.State.ToString(), "UNIPOL");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "UNIPOL");
            //}

        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Enter || e.Key == Key.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUsuario.Text))
                {
                    var usuario = _bo.ConsultaUsuario(Convert.ToInt32(txtUsuario.Text));
                    if (usuario.Data.Count > 0)
                    {
                        txtNombreUsuario.Text = usuario.Data[0].Nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L - " + ex.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnIniciarSesion.Focus();
            }
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("Proporcione un usuario", "UNIPOL", MessageBoxButton.OK,MessageBoxImage.Information);
                    txtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPass.Password.ToString()))
                {
                    MessageBox.Show("Proporcione una Contraseña", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtPass.Focus();
                    return;
                }

                var r = _bo.ValidaUsuario(Convert.ToInt32(txtUsuario.Text), txtPass.Password.ToString());

                if (r.Value)
                {
                    if (r.Data.Count > 0)
                    {
                        Globales.usuarioActivo = r.Data[0];
                        Globales.UsuarioValido = true;
                        //usuarioValido = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show(r.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L - " + ex.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
