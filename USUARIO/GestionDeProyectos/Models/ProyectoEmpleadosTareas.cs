using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDeProyectos.Models
{
    public class ProyectoEmpleadosTareas
    {
        public string TAREA_ID { get; set; }
        public string PROYECTO_ID { get; set; }
        public string EMPLEADO_ID { get; set; }
        public string DIA { get; set; }
        public string SUBTAREA_ID { get; set; }
        public int TIEMPO { get; set; }
        public string OBSERVACION { get; set; }

        public ProyectoEmpleadosTareas(string tAREA_ID, string pROYECTO_ID, string eMPLEADO_ID, string dIA, string sUBTAREA_ID, int tIEMPO, string oBSERVACION)
        {
            TAREA_ID = tAREA_ID;
            PROYECTO_ID = pROYECTO_ID;
            EMPLEADO_ID = eMPLEADO_ID;
            DIA = dIA;
            SUBTAREA_ID = sUBTAREA_ID;
            TIEMPO = tIEMPO;
            OBSERVACION = oBSERVACION;
        }

        public ProyectoEmpleadosTareas()
        {
        }
    }
        
}