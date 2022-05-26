using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIPOL.EN;

namespace UNIPOL.Medicos
{
    public class ConsultasMedicasVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<ArticulosReceta> lstArticulos { get; set; }
        public int pacienteCodigo { get; set; }
        public string pacienteNombre { get; set; }
        public int medicamentoCodigo { get; set; }
        public string medicamentoDescripcion { get; set; }
        public int medicamentoCantidad { get; set; }
        public string medicamentoObservacion { get; set; }

        public ConsultasMedicasVM()
        {
            this.lstArticulos = new List<ArticulosReceta>();
            this.pacienteCodigo = 1;
            this.pacienteNombre = "Paciente de prueba";
            this.medicamentoCodigo = 10;
            this.medicamentoDescripcion = "Medicamento de prueba";
            this.medicamentoCantidad = 1;
            this.medicamentoObservacion = "";
        }

        public void AgregarMedicamento()
        {
            var a = new ArticulosReceta();
            a.CodArticulo = this.medicamentoCodigo;
            a.Cantidad = this.medicamentoCantidad;
            a.Descripcion = this.medicamentoDescripcion;
            a.Observacion = this.medicamentoObservacion;
            this.lstArticulos.Add(a);
            
        }
    }
}
