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
using UNIPOL.EN.Configuracion;

namespace UNIPOL
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ConfiguracionBO _bo = null;

        public bool usuarioValido { get; set; }

        public Login()
        {
            _bo = new ConfiguracionBO();
            InitializeComponent();
            usuarioValido = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPass.Focus();
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

            var r = _bo.ValidaUsuaario(Convert.ToInt32(txtUsuario.Text), txtPass.Password.ToString());

            if (r.Value)
            {
                if (r.Data.Count > 0)
                {
                    this.usuarioValido = true;
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
    }
}
