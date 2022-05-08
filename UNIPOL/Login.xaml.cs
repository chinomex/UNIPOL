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
        LoginVM _vm = null;
        public bool usuarioValido { get; set; }

        public Login()
        {
            _vm = new LoginVM();
            this.DataContext = _vm;

            InitializeComponent();
        }

        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            usuarioValido = true;
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            usuarioValido = false;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
