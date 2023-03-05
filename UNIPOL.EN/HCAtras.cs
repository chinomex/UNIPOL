using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class HCAtras : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public decimal Estatura { get; set; }
        public decimal Peso { get; set; }
        public decimal IMC => Estatura;

    }
}
