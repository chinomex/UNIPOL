﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIPOL.EN
{
    public class HistoriaClinicaHistoria
    {
        public int IdHistoria { get; set; }
        public int CodPaciente { get; set; }
        public string Paciente { get; set; }
        public int CodUsuario { get; set; }
        public string Medico { get; set; }
        public DateTime FechaHistoria { get; set; }
    }
}
