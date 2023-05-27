using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIPOL.EN;
using UNIPOL.BO;
using System.Windows;

namespace UNIPOL.General
{
    public class BuscadorVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<DatosBusqueda> DatosBusqueda { get; set; }
        public string TituloBusqueda { get; set; }
        public int TipoBusqueda { get; set; }
        public string txtBuscar { get; set; }
        public int withBuscador { get; set; }

        BusquedaBO _bo = null;

        public BuscadorVM(int tipoBusqueda)
        {
            _bo = new BusquedaBO();

            switch(tipoBusqueda)
            {
                case 1:
                    this.TituloBusqueda = "Buscar Paciente";
                    this.TipoBusqueda = 1;
                    this.withBuscador = 425;
                    break;
                case 2:
                    this.TituloBusqueda = "Buscar Medicamento";
                    this.TipoBusqueda = 2;
                    this.withBuscador = 485;
                    break;
            }
        }

        public void Buscar()
        {
            var r = _bo.Busqueda(this.txtBuscar, this.TipoBusqueda);
            if (r.Value)
            {
                if (r.Data.Count > 0)
                {
                    DatosBusqueda = r.Data;
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show(r.Message, "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


    }
}
