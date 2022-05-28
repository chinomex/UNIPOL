using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class ArticulosReceta: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int CodArticulo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
    }
}
