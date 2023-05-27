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
using UNIPOL.EN;

namespace UNIPOL.General
{
    /// <summary>
    /// Lógica de interacción para Buscador.xaml
    /// </summary>
    public partial class Buscador : Window
    {
        BuscadorVM _vm = null;
        public DatosBusqueda itemBusqueda;

        public Buscador(int tipoBusqueda)
        {
            _vm = new BuscadorVM(tipoBusqueda);
            this.DataContext = _vm;
            itemBusqueda = new DatosBusqueda();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtBuscador.Focus();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            _vm.Buscar();
        }

        private void txtBuscador_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(txtBuscador.Text))
                {
                    _vm.Buscar();
                }
            }
        }

        private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            itemBusqueda = (sender as DataGrid).SelectedItem as DatosBusqueda;
            if (itemBusqueda != null)
            {
                itemBusqueda.seleccionado = true;
                this.Close();
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Medicos.AltaPaciente alta = new Medicos.AltaPaciente();
            alta.ShowDialog();
            if(alta.CodPaciente > 0)
            {
                _vm.txtBuscar = alta.NombrePaciente;
                _vm.Buscar();
            }
        }
    }
}
