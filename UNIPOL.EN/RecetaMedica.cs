using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class RecetaMedica
    {
        public int IdReceta { get; set; }
        public int CodPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public int CodUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int Tipo { get; set; }
        public string Universidad { get; set; }
        public string Cedula { get; set; }
        public string RegistroSSA { get; set; }
        public DateTime Fecha { get; set; }
        public int CodArticulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Estatus { get; set; }
        public int Cantidad { get; set; }
        public string Observaciones { get; set; }
        public int Edad { get; set; }
        public string EdadCompleta { get; set; }

        public int TA { get; set; }
        public int FC { get; set; }
        public int FR { get; set; }
        public decimal TEM { get; set; }
    }
}
