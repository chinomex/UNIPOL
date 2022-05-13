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

namespace UNIPOL.Inventarios
{
    /// <summary>
    /// Lógica de interacción para Existencias.xaml
    /// </summary>
    public partial class Existencias : Window
    {
        public Existencias()
        {
            InitializeComponent();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                dpCaducidad.Focus();
            }
        }

        private void dpCaducidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtExistencia.Focus();
            }
        }

        private void txtExistencia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnGuardar.Focus();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Guardar");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtCodigo.Focus();
        }
    }
}
