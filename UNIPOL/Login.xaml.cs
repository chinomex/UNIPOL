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

namespace UNIPOL
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public bool usuarioValido { get; set; }

        public Login()
        {
            InitializeComponent();
            usuarioValido = false;
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            this.usuarioValido = true;
            this.Close();
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
            txtPass.Focus();
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            btnIniciarSesion.Focus();
        }
    }
}
