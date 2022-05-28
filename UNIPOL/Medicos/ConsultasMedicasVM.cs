using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIPOL.EN;

namespace UNIPOL.Medicos
{
    public class ConsultasMedicasVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ArticulosReceta> Articulos { get; set; }
        public ArticulosReceta articuloActual { get; set; }
        public int pacienteCodigo { get; set; }
        public string pacienteNombre { get; set; }
        public int medicamentoCodigo { get; set; }
        public string medicamentoDescripcion { get; set; }
        public int medicamentoCantidad { get; set; }
        public string medicamentoObservacion { get; set; }



       public ConsultasMedicasVM()
        {
            this.Articulos = new ObservableCollection<ArticulosReceta>();
            this.pacienteCodigo = 1;
            this.pacienteNombre = "Paciente de prueba";
            this.medicamentoCodigo = 10;
            this.medicamentoDescripcion = "Medicamento de prueba";
            this.medicamentoCantidad = 1;
            this.medicamentoObservacion = "";


            //var a = new ArticulosReceta();
            //a.CodArticulo = 10;
            //a.Descripcion = "algo";
            //a.Cantidad = 1;
            //a.Observacion = "dato";
            //this.Articulos.Add(a);

            //a = new ArticulosReceta();
            //a.CodArticulo = 10;
            //a.Descripcion = "algo";
            //a.Cantidad = 1;
            //a.Observacion = "dato";
            //this.Articulos.Add(a);


            //a = new ArticulosReceta();
            //a.CodArticulo = 10;
            //a.Descripcion = "algo";
            //a.Cantidad = 1;
            //a.Observacion = "dato";
            //this.Articulos.Add(a);

        }




        public void AgregarMedicamento()
        {
            var a = new ArticulosReceta();
            a.CodArticulo = this.medicamentoCodigo;
            a.Descripcion = this.medicamentoDescripcion;
            a.Cantidad = this.medicamentoCantidad;
            a.Observacion = this.medicamentoObservacion;
            this.Articulos.Add(a);
        }
    }
}
