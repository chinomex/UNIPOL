using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class RecetaMedica
    {
        public RecetaMedica()
        {
            Encabezado = new DatosReceta();
            Detalle = new DatosRecetaDetalle();
        }
        public DatosReceta Encabezado { get; set; }
        public DatosRecetaDetalle Detalle { get; set; }
    }
}
