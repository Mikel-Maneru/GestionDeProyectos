using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDeProyectos.Models
{
    public class Proyectos
    {
        public string PROYECTO_ID { get; set; }
        public string CLIENTE_ID { get; set; }
        public string NEGOCIO_ID { get; set; }
        public string CENTROCOSTE_ID { get; set; }
        public string NOMBREPROYECTO { get; set; }
        public string RESUMENPROYECTO { get; set; }
        public string TIPOPROYECTO { get; set; }
        public string PLAZO { get; set; }
        public string ESTADO { get; set; }
        public string MODALIDAD { get; set; }
    }
}