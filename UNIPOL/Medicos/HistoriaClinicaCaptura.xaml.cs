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
using UNIPOL.General;

namespace UNIPOL.Medicos
{
    /// <summary>
    /// Lógica de interacción para HistoriaClinicaCaptura.xaml
    /// </summary>
    public partial class HistoriaClinicaCaptura : Window
    {
        HistoriaClinicaCapturaVM _vm = null;
        public HistoriaClinicaCaptura()
        {
            InitializeComponent();
            _vm = new HistoriaClinicaCapturaVM();
            this.DataContext = _vm;
        }

        private void btnBuscarPaciente_Click(object sender, RoutedEventArgs e)
        {
            Buscador buscador = new Buscador(1);
            buscador.Owner = this;
            buscador.ShowDialog();
            if (buscador.itemBusqueda != null && buscador.itemBusqueda.seleccionado)
            {
                _vm.pacienteCodigo = buscador.itemBusqueda.Codigo;
                _vm.pacienteNombre = buscador.itemBusqueda.Descripcion;
                _vm.ConsultaPaciente();
            }
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tbHistoria.SelectedIndex + 1;
            if (newIndex >= tbHistoria.Items.Count)
                newIndex = 0;
            tbHistoria.SelectedIndex = newIndex;
            BotonesTab();

            //int newIndex = tbHistoria.SelectedIndex + 1;
            //if (newIndex >= tbHistoria.Items.Count -1)
            //{
            //    btnAnterior.Visibility = Visibility.Visible;
            //    btnSiguiente.Visibility = Visibility.Collapsed;
            //    btnGuardar.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    btnAnterior.Visibility = Visibility.Visible;
            //    btnSiguiente.Visibility = Visibility.Visible;
            //    btnGuardar.Visibility = Visibility.Collapsed;
            //}
            //tbHistoria.SelectedIndex = newIndex;
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tbHistoria.SelectedIndex - 1;
            if (newIndex < 0)
                newIndex = tbHistoria.Items.Count - 1;
            tbHistoria.SelectedIndex = newIndex;
            BotonesTab();

            //int newIndex = tbHistoria.SelectedIndex - 1;
            //if (newIndex <= 0)
            //{
            //    btnAnterior.Visibility = Visibility.Collapsed;
            //    btnSiguiente.Visibility = Visibility.Visible;
            //    btnGuardar.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    btnAnterior.Visibility = Visibility.Visible;
            //    btnSiguiente.Visibility = Visibility.Visible;
            //    btnGuardar.Visibility = Visibility.Collapsed;
            //}
            //tbHistoria.SelectedIndex = newIndex;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbHistoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BotonesTab();
        }

        private void BotonesTab()
        {
            switch (tbHistoria.SelectedIndex)
            {
                case 0:
                    btnAnterior.Visibility = Visibility.Collapsed;
                    btnSiguiente.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    btnAnterior.Visibility = Visibility.Visible;
                    btnSiguiente.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    btnAnterior.Visibility = Visibility.Visible;
                    btnSiguiente.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    btnAnterior.Visibility = Visibility.Visible;
                    btnSiguiente.Visibility = Visibility.Collapsed;
                    btnGuardar.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
