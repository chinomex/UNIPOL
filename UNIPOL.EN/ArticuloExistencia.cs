using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class ArticuloExistencia
    {
        public int CodArticulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Caducidad { get; set; }
        public int Existencia { get; set; }
    }
}
