using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIPOL.EN;

namespace UNIPOL.General
{
    public class BuscadorVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DatoBusqueda> DatosBusqueda { get; set; }
        public string TipoBusqueda { get; set; }

        public BuscadorVM(int tipoBusqueda)
        {
            switch(tipoBusqueda)
            {
                case 1:
                    this.TipoBusqueda = "Buscar Paciente";
                    break;
                case 2:
                    this.TipoBusqueda = "Buscar Medicamento";
                    break;
            }
            
        
        }

    }
}
