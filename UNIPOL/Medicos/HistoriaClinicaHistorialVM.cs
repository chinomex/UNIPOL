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
    public class HistoriaClinicaHistorialVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        MedicosBO _bo = null;

        public HistoriaClinicaHistorialVM()
        {
            _bo = new MedicosBO();
        }

        public List<HistoriaClinicaHistoria> lstHistorial { get; set; }
        public HistoriaClinicaHistoria HistoriaSeleccionada { get; set; }
        public int pacienteCodigo { get; set; }
        public string pacienteNombre { get; set; }
        public int NoHistorias { get; set; }
        public void CargaHistorial(int codPaciente, int codUsuario, DateTime fi, DateTime ff)
        {
            //lstHistorial = new List<HistoriaClinicaHistoria>();
            //HistoriaClinicaHistoria historia = new HistoriaClinicaHistoria();
            //historia.CodPaciente = 1;
            //historia.Paciente = "Paciente 1";
            //historia.FechaHistoria = new DateTime(2023, 1, 1);
            //lstHistorial.Add(historia);

            //historia = new HistoriaClinicaHistoria();
            //historia.CodPaciente = 2;
            //historia.Paciente = "Paciente 2";
            //historia.FechaHistoria = new DateTime(2023, 2, 15);
            //lstHistorial.Add(historia);

            //historia = new HistoriaClinicaHistoria();
            //historia.CodPaciente = 3;
            //historia.Paciente = "Paciente 3";
            //historia.FechaHistoria = new DateTime(2023, 3, 20);
            //lstHistorial.Add(historia);

            //historia = new HistoriaClinicaHistoria();
            //historia.CodPaciente = 4;
            //historia.Paciente = "Paciente 4";
            //historia.FechaHistoria = new DateTime(2023, 4, 10);
            //lstHistorial.Add(historia);

            var listado = _bo.ConsultaHistorial(codPaciente, codUsuario, fi, ff);
            lstHistorial = listado.Data;
            NoHistorias = listado.Data.Count;

        }
    }
}
