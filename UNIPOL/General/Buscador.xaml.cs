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

namespace UNIPOL.General
{
    /// <summary>
    /// Lógica de interacción para Buscador.xaml
    /// </summary>
    public partial class Buscador : Window
    {
        BuscadorVM _vm = null;
        public Buscador(int tipoBusqueda)
        {
            _vm = new BuscadorVM(tipoBusqueda);
            this.DataContext = _vm;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtBuscador.Focus();
        }
    }
}
