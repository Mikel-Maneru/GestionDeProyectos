using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDeProyectos.Models
{
    public class ProyectoEmpleadoGastos
    {
        public string GASTOS_ID { get; set; }
        public string PROYECTO_ID { get; set; }
        public string EMPLEADO_ID { get; set; }
        public string DIA { get; set; }
        public string CONCEPTO { get; set; }
        public string OBSERVACION { get; set; }
        public int COSTE { get; set; }
        public int KM { get; set; }
        public string DIETA { get; set; }

        public ProyectoEmpleadoGastos(string gASTOS_ID, string pROYECTO_ID, string eMPLEADO_ID, string dIA, string cONCEPTO, string oBSERVACION, int cOSTE, int kM, string dIETA)
        {
            GASTOS_ID = gASTOS_ID;
            PROYECTO_ID = pROYECTO_ID;
            EMPLEADO_ID = eMPLEADO_ID;
            DIA = dIA;
            CONCEPTO = cONCEPTO;
            OBSERVACION = oBSERVACION;
            COSTE = cOSTE;
            KM = kM;
            DIETA = dIETA;
        }

        public ProyectoEmpleadoGastos()
        {
        }
    }
}