using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UNIPOL.Medicos
{
    /// <summary>
    /// Lógica de interacción para ConsultasMedicas.xaml
    /// </summary>
    public partial class ConsultasMedicas : Window
    {
        //List<ArticulosReceta> lstArticulos = null;
        public ObservableCollection<ArticulosReceta> lstArticulos { get; set; }
        public ConsultasMedicas()
        {
            lstArticulos = new ObservableCollection<ArticulosReceta>();
            ArticulosReceta a = new ArticulosReceta();
            a.CodArticulo = 10;
            a.Descripcion = "Descripcion de articulo";
            a.Cantidad = 1;
            a.Observacion = "Despues de los alimentos";
            lstArticulos.Add(a);

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
