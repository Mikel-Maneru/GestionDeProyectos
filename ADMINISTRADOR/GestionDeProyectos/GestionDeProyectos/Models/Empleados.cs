using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



namespace GestionDeProyectos.Models
{
    public class Empleados
    {
        public string EMPLEADO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public string MANODEOBRA { get; set; }
        public string ROL_ID { get; set; }

    }
}