using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.Configuracion
{
   public class UsuariosVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool esMedico { get; set; }

        public UsuariosVM()
        {
            esMedico = true;
        }
    }
}
