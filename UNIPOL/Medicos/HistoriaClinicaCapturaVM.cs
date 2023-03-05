using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIPOL.BO;
using UNIPOL.EN;

namespace UNIPOL.Medicos
{
    public class HistoriaClinicaCapturaVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        MedicosBO _bo = null;
        public HistoriaClinicaCapturaVM()
        {
            _bo = new MedicosBO();
            CargaListados();
        }

        public int pacienteCodigo { get; set; }
        public string pacienteNombre { get; set; }
        public string pacienteFechaNacimiento { get; set; }
        public string pacienteEdad { get; set; }
        public string pacienteTelefono { get; set; }
        public List<EstadoCivil> lstEstadosCiviles { get; set; }
        public EstadoCivil EstadoCivilSeleccionado { get; set; }
        public List<Sexo> lstSexos { get; set; }
        public Sexo SexoSeleccionado { get; set; }

        public List<ListaCombo> lstInmunizaciones { get; set; }
        public ListaCombo InmunizacionSeleccionado { get; set; }

        public List<ListaCombo> lstMPF { get; set; }
        public ListaCombo MPFSeleccionado { get; set; }

        public List<ListaCombo> lstGrupoSanguineo { get; set; }
        public ListaCombo GrupoSanguineoSeleccionado { get; set; }

        public List<ListaCombo> lstFactor { get; set; }
        public ListaCombo FactorSeleccionado { get; set; }

        public List<ListaCombo> lstPenicilina { get; set; }
        public ListaCombo PenicilinaSeleccionado { get; set; }

        public List<ListaCombo> lstTransmisionSexual { get; set; }
        public ListaCombo TransmisionSexualSeleccionado { get; set; }

        public List<ListaCombo> lstSida { get; set; }
        public ListaCombo SidaSeleccionado { get; set; }

        public List<ListaCombo> lstDroga { get; set; }
        public ListaCombo DrogaSeleccionado { get; set; }

        public List<ListaCombo> lstCocaina { get; set; }
        public ListaCombo CocainaSeleccionado { get; set; }

        public List<ListaCombo> lstMariguana { get; set; }
        public ListaCombo MariguanaSeleccionado { get; set; }

        public List<ListaCombo> lstPsicofarmacos { get; set; }
        public ListaCombo PsicofarmacosSeleccionado { get; set; }

        public List<ListaCombo> lstTatuajes { get; set; }
        public ListaCombo TatuajeSeleccionado { get; set; }

        public List<ListaCombo> lstAlcohol { get; set; }
        public ListaCombo AlcoholSeleccionado { get; set; }

        public List<ListaCombo> lstTabaquismo { get; set; }
        public ListaCombo TabaquismoSeleccionado { get; set; }

        public List<ListaCombo> lstDeportes { get; set; }
        public ListaCombo DeporteSeleccionado { get; set; }

        public List<ListaCombo> lstPsiquiatrico { get; set; }
        public ListaCombo PsiquiatricoSeleccionado { get; set; }

        public List<ListaCombo> lstPsicologico { get; set; }
        public ListaCombo PsicologicoSeleccionado { get; set; }


        public decimal Estatura { get; set; }
        public decimal Peso { get; set; }
        public decimal IMC { get; set; }
        public void ConsultaPaciente()
        {
            var r = _bo.ConsultaPaciente(pacienteCodigo);
            if(r.Value)
            {
                pacienteFechaNacimiento = r.Data[0].FechaNacimiento.ToShortDateString();
                pacienteEdad = r.Data[0].EdadCompleta;
                pacienteTelefono = r.Data[0].Telefono;
            }
        }


        private void CargaListados()
        {

            lstEstadosCiviles = new List<EstadoCivil>();
            EstadoCivil ec = new EstadoCivil();
            ec.CodEstadoCivil = 1;
            ec.Descripcion = "SOLTERO";
            lstEstadosCiviles.Add(ec);

            ec = new EstadoCivil();
            ec.CodEstadoCivil = 2;
            ec.Descripcion = "CASADO";
            lstEstadosCiviles.Add(ec);

            ec = new EstadoCivil();
            ec.CodEstadoCivil = 3;
            ec.Descripcion = "DIVORCIADO";
            lstEstadosCiviles.Add(ec);

            ec = new EstadoCivil();
            ec.CodEstadoCivil = 4;
            ec.Descripcion = "UNION LIBRE";
            lstEstadosCiviles.Add(ec);

            lstSexos = new List<Sexo>();
            Sexo s = new Sexo();
            s.CodSexo = 1;
            s.Descripcion = "MASCULINO";
            lstSexos.Add(s);

            s = new Sexo();
            s.CodSexo = 2;
            s.Descripcion = "FEMENINO";
            lstSexos.Add(s);


            ListaCombo i = new ListaCombo();
            lstMPF = new List<ListaCombo>();
            i.Codigo = 1;
            i.Descripcion = "NINGUNO";
            lstMPF.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "PASTILLA ANTICONCEPTIVA";
            lstMPF.Add(i);

            i = new ListaCombo();
            i.Codigo = 3;
            i.Descripcion = "HORMONAL INYECTADO";
            lstMPF.Add(i);

            i = new ListaCombo();
            i.Codigo = 4;
            i.Descripcion = "DIU";
            lstMPF.Add(i);

            i = new ListaCombo();
            i.Codigo = 5;
            i.Descripcion = "IMPLANTE SUBDERMICO";
            lstMPF.Add(i);



            lstInmunizaciones = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "COMPLETA";
            lstInmunizaciones.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "INCOMPLETA";
            lstInmunizaciones.Add(i);


            lstGrupoSanguineo = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "A";
            lstGrupoSanguineo.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "AB";
            lstGrupoSanguineo.Add(i);

            i = new ListaCombo();
            i.Codigo = 3;
            i.Descripcion = "B";
            lstGrupoSanguineo.Add(i);

            i = new ListaCombo();
            i.Codigo = 4;
            i.Descripcion = "O";
            lstGrupoSanguineo.Add(i);


            lstFactor = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "( + )";
            lstFactor.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "( - )";
            lstFactor.Add(i);



            lstPenicilina = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstPenicilina.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstPenicilina.Add(i);



            lstTransmisionSexual = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstTransmisionSexual.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstTransmisionSexual.Add(i);



            lstSida = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstSida.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstSida.Add(i);



            lstDroga = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstDroga.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstDroga.Add(i);



            lstCocaina = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstCocaina.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstCocaina.Add(i);



            lstMariguana = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstMariguana.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstMariguana.Add(i);



            lstPsicofarmacos = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstPsicofarmacos.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstPsicofarmacos.Add(i);



            lstTatuajes = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "0";
            lstTatuajes.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "1";
            lstTatuajes.Add(i);

            i = new ListaCombo();
            i.Codigo = 3;
            i.Descripcion = "2";
            lstTatuajes.Add(i);

            i = new ListaCombo();
            i.Codigo = 4;
            i.Descripcion = "3";
            lstTatuajes.Add(i);

            i = new ListaCombo();
            i.Codigo = 5;
            i.Descripcion = "4";
            lstTatuajes.Add(i);

            i = new ListaCombo();
            i.Codigo = 6;
            i.Descripcion = "+5";
            lstTatuajes.Add(i);



            lstAlcohol = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstAlcohol.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstAlcohol.Add(i);


            lstDeportes = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstDeportes.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstDeportes.Add(i);



            lstTabaquismo = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstTabaquismo.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstTabaquismo.Add(i);


            lstPsiquiatrico = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstPsiquiatrico.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstPsiquiatrico.Add(i);


            lstPsicologico = new List<ListaCombo>();
            i = new ListaCombo();
            i.Codigo = 1;
            i.Descripcion = "SI";
            lstPsicologico.Add(i);

            i = new ListaCombo();
            i.Codigo = 2;
            i.Descripcion = "NO";
            lstPsicologico.Add(i);
        }
    }
}
