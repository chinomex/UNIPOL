﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UNIPOL.DA;
using UNIPOL.EN;
using WarmPack.Classes;


namespace UNIPOL.BO
{
    public class MedicosBO
    {
        MedicosDA _da = null;
        public MedicosBO()
        {
            _da = new MedicosDA();
        }

        public Result<List<DatosPaciente>> ConsultaPaciente(int codPaciente)
        {
            return _da.ConsultaPaciente(codPaciente);
        }

        public Result<List<DatosPaciente>> GuardarPaciente(int codPaciente, string nombre, int idGenero, string domicilio, DateTime fechaNacimiento, string telefono, string correo, string rfc, string alergias)
        {
            return _da.GuardarPaciente(codPaciente, nombre, idGenero, domicilio, fechaNacimiento, telefono, correo, rfc, alergias);
        }



        public Result<int> GuardarReceta(int codPaciente, int codMedico, int pacienteTA, int pacienteFC, int pacienteFR, decimal pacienteTEM, string txtNotaEvolucion, List<ArticulosReceta> articulos)
        {
            return _da.GuardarReceta(codPaciente, codMedico, pacienteTA, pacienteFC, pacienteFR, pacienteTEM, txtNotaEvolucion, articulos);
        }

        public Result<List<RecetaMedica>> Receta(int idReceta)
        {
            return _da.Receta(idReceta);
        }

        public Result<List<RecetaMedica>> RecetaHistorial(int CodPaciente)
        {
            return _da.RecetaHistorial(CodPaciente);
        }

        public Result<int> UltimaReceta(int codMedico)
        {
            return _da.UltimaReceta(codMedico);

        }

        public Result<int> guardarHistoriaClinica(HC xml)
        {
            return _da.guardarHistoriaClinica(xml);
        }

        public Result ConsultaHistoriaClinia(int idHistoria, ref DataSet ds)
        {
            return _da.ConsultaHistoriaClinia(idHistoria,ref ds);
        }

        public Result<List<HistoriaClinicaHistoria>> ConsultaHistorial(int codPaciente, int codUsuario, DateTime fi, DateTime ff)
        {
            return _da.ConsultaHistorial(codPaciente, codUsuario, fi, ff);
        }

        public Result<List<ConsultaMedicaHistoria>> ConsultaMedicaHistorial(int codPaciente, int codUsuario, DateTime fi, DateTime ff)
        {
            return _da.ConsultaMedicaHistorial(codPaciente, codUsuario, fi, ff);
        }
    }
}
