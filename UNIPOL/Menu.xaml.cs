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
using UNIPOL.Catalogos;
using UNIPOL.Inventarios;
using UNIPOL.Medicos;

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

        private void mnCatalogoUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Owner = this;
            usuarios.ShowDialog();
        }

        private void mnInvExistencias_Click(object sender, RoutedEventArgs e)
        {
            Existencias existencias = new Existencias();
            existencias.Owner = this;
            existencias.ShowDialog();
        }

        private void mnMedicoAltaPaciente_Click(object sender, RoutedEventArgs e)
        {
            AltaPaciente altaPaciente = new AltaPaciente();
            altaPaciente.Owner = this;
            altaPaciente.ShowDialog();
        }

        private void mnMedicoConsultar_Click(object sender, RoutedEventArgs e)
        {
            ConsultasMedicas consultasMedicas = new ConsultasMedicas();
            consultasMedicas.Owner = this;
            consultasMedicas.ShowDialog();
        }


    }
}
