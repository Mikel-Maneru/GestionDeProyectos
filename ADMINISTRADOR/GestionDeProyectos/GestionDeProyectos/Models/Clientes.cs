using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



namespace GestionDeProyectos.Models
{
    public class Clientes
    {
        public string CLIENTE_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
        public string CIF { get; set; }

    }
}