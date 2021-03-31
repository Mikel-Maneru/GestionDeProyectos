using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDeProyectos.Models
{
    public class ProyectoEmpleado
    {
        public string PROYECTO_ID { get; set; }
        public string EMPLEADO_ID { get; set; }
        public int HORAS{ get; set; }
    }
}