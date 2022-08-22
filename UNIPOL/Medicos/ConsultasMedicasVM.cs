using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIPOL.EN;
using UNIPOL.BO;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows;

namespace UNIPOL.Medicos
{
    public class ConsultasMedicasVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ArticulosReceta> Articulos { get; set; }
        public ArticulosReceta articuloActual { get; set; }
        public int pacienteCodigo { get; set; }
        public string pacienteNombre { get; set; }
        public int pacienteTA { get; set; }
        public int pacienteFC { get; set; }
        public decimal pacienteTEM { get; set; }
        public int medicamentoCodigo { get; set; }
        public string medicamentoDescripcion { get; set; }
        public int medicamentoCantidad { get; set; }
        public string medicamentoObservacion { get; set; }

        MedicosBO _bo = null;

       public ConsultasMedicasVM()
        {
            this.Articulos = new ObservableCollection<ArticulosReceta>();
            _bo = new MedicosBO();
        }




        public void AgregarMedicamento()
        {
            var a = new ArticulosReceta();
            a.CodArticulo = this.medicamentoCodigo;
            a.Descripcion = this.medicamentoDescripcion;
            a.Cantidad = this.medicamentoCantidad;
            a.Observacion = this.medicamentoObservacion;
            this.Articulos.Add(a);

            this.medicamentoCodigo = 0;
            this.medicamentoDescripcion = "";
            this.medicamentoCantidad = 0;
            this.medicamentoObservacion = "";
        }

        public bool guardar()
        {
            
            var result = _bo.GuardarReceta(this.pacienteCodigo, Globales.usuarioActivo.IdUsuario, this.pacienteTA, this.pacienteFC, this.pacienteTEM, this.Articulos.ToList<ArticulosReceta>());
            if (result.Value)
            {
                var receta = _bo.Receta(result.Data);
                if (receta.Value)
                {
                    if (receta.Data.Count > 0)
                    {
                        var d = receta.Data;
                        ReportDocument reporte = new ReportDocument();
                        var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                        reporte.Load(path + @"\Reportes\rptReceta.rpt");
                        reporte.SetDataSource(d);
                        Reportes.Reporteador reportView = new Reportes.Reporteador(reporte, 90);
                        reportView.WindowState = System.Windows.WindowState.Maximized;
                        reportView.Title = "Existencias";
                        reportView.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron resultados", "UNIPOL", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    Limpiar();
                }

                return receta.Value;
            }

            return result.Value;
        }

        private void Limpiar()
        {
            this.Articulos = new ObservableCollection<ArticulosReceta>();
            this.articuloActual = new ArticulosReceta();
            this.pacienteCodigo = 0;
            this.pacienteTA = 0;
            this.pacienteFC = 0;
            this.pacienteTEM = 0;
            this.pacienteNombre = "";
            this.medicamentoCodigo = 0;
            this.medicamentoDescripcion = "";
            this.medicamentoCantidad = 0;
            this.medicamentoObservacion = "";
    }
    }
}
