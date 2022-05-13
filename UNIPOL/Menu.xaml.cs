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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UNIPOL
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Owner = this;
            login.ShowDialog();
            if (!login.usuarioValido)
            {
                this.Close();
            }
        }

        private void MnConfigUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Configuracion.Usuarios usuarios = new Configuracion.Usuarios();
            usuarios.Owner = this;
            usuarios.ShowDialog();
        }

        private void mnInvExistencias_Click(object sender, RoutedEventArgs e)
        {
            Inventarios.Existencias existencias = new Inventarios.Existencias();
            existencias.Owner = this;
            existencias.ShowDialog();
        }

        private void mnMedicoAltaPaciente_Click(object sender, RoutedEventArgs e)
        {
            Medicos.AltaPaciente altaPaciente = new Medicos.AltaPaciente();
            altaPaciente.Owner = this;
            altaPaciente.ShowDialog();
        }
    }
}
