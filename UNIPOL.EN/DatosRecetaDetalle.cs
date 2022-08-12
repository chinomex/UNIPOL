using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class DatosRecetaDetalle
    {
        public int IdReceta { get; set; }
        public int CodArticulo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Observaciones { get; set; }
    }
}
