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
    /// Lógica de interacción para MostrarImagen.xaml
    /// </summary>
    public partial class MostrarImagen : Window
    {
        public int tipoImagen { get; set; }
        public MostrarImagen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string NombreImagen = "";
                switch(tipoImagen)
                {
                    case 1:
                        NombreImagen = "imageTA.jpg";
                        break;
                    case 2:
                        NombreImagen = "imageFR.png";
                        break;
                    case 3:
                        NombreImagen = "imageFC.jpg";
                        break;
                    default:
                        NombreImagen = "NoDisponible.png";
                        break;
                }    

                string rutaImagen = "pack://application:,,,/UNIPOL;component/Imagenes/" + NombreImagen;
                BitmapImage imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri(rutaImagen);
                imagen.EndInit();
                img.Source = imagen;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
