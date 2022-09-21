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
using UNIPOL.EN;
using UNIPOL.BO;
using CrystalDecisions.CrystalReports.Engine;

namespace UNIPOL
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InventariosBO _boInventario = null;
        public MainWindow()
        {
            _boInventario = new InventariosBO();
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Login login = new Login();
                login.Owner = this;
                login.ShowDialog();
                if (!Globales.UsuarioValido)
                {
                    this.Close();
                }
                else
                {
                    if (!Globales.usuarioActivo.esMedico)
                    {
                        mnMedico.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        mnConfig.Visibility = Visibility.Collapsed;
                        mnInventario.Visibility = Visibility.Collapsed;
                        mnReportes.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("M01 -" + ex.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void mnCatalogoUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Owner = this;
            usuarios.ShowDialog();
        }

        private void mnCatalogoArticulos_Click(object sender, RoutedEventArgs e)
        {
            Articulos articulos = new Articulos();
            articulos.Owner = this;
            articulos.ShowDialog();
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

        private void mnRepExistencias_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                var r = _boInventario.ExistenciaArticulo(0);
                if (r.Value)
                {
                    if (r.Data.Count > 0)
                    {
                        var d = r.Data;
                        ReportDocument reporte = new ReportDocument();
                        var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                        reporte.Load(path + @"\Reportes\rptExistencias.rpt");
                        reporte.SetDataSource(d);
                        Reportes.Reporteador reportView = new Reportes.Reporteador(reporte, 90);
                        reportView.WindowState = System.Windows.WindowState.Maximized;
                        reportView.Title = "Existencias";
                        reportView.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron resultados", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }            
            }
            catch(Exception ex)
            {
                MessageBox.Show("M02 -" + ex.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
