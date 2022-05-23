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

        public ConsultasMedicasVM()
        {
            lstArticulos = new List<ArticulosReceta>();
            ArticulosReceta a = new ArticulosReceta();
            a.CodArticulo = 10;
            a.Descripcion = "Descripcion de articulo";
            a.Cantidad = 1;
            a.Observacion = "Despues de los alimentos";
            lstArticulos.Add(a);

            a = new ArticulosReceta();
            a.CodArticulo = 20;
            a.Descripcion = "Descripcion de articulo";
            a.Cantidad = 1;
            a.Observacion = "Despues de los alimentos";
            lstArticulos.Add(a);

            a = new ArticulosReceta();
            a.CodArticulo = 30;
            a.Descripcion = "Descripcion de articulo";
            a.Cantidad = 1;
            a.Observacion = "Despues de los alimentos";
            lstArticulos.Add(a);

            a = new ArticulosReceta();
            a.CodArticulo = 40;
            a.Descripcion = "Descripcion de articulo";
            a.Cantidad = 1;
            a.Observacion = "Despues de los alimentos";
            lstArticulos.Add(a);

            a = new ArticulosReceta();
            a.CodArticulo = 50;
            a.Descripcion = "Descripcion de articulo";
            a.Cantidad = 1;
            a.Observacion = "Despues de los alimentos";
            lstArticulos.Add(a);
        }
    }
}
