using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Result<List<DatosPaciente>> GuardarPaciente(int codPaciente, string nombre, string domicilio, DateTime fechaNacimiento, string telefono, string correo)
        {
            return _da.GuardarPaciente(codPaciente, nombre, domicilio, fechaNacimiento, telefono, correo);
        }
    }
}
