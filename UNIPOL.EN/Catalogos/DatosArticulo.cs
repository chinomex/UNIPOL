using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN.Catalogos
{
    public class DatosArticulo
    {
        public int CodArticulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Estatus { get; set; }
    }
}
