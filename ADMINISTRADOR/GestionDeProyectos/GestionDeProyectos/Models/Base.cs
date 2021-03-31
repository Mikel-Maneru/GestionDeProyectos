using AbCommon.DB.Conexion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;



namespace GestionDeProyectos.Models
{
    class Base
    {
        protected static ABConexion _db = null;
        protected static string ConnectionString;
        protected static string DefaultSchema;
        protected static string msgError;



        protected static bool OpenDB()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["gdp"].ConnectionString;
            return (OpenDB(ConnectionString));
        }



        protected static bool OpenDB(string conString)
        {
            msgError = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(conString) == false)
                    ConnectionString = conString;



                DefaultSchema = "GESTION_PROYECTOS";
                _db = new ABConexionBuilder().CreateConexion(ABConexionBuilder.TipoDB.Oracle.ToString(),
                                                             ConnectionString,
                                                             DefaultSchema);
            }
            catch (Exception ex)
            {
                msgError = $"#1# {ex.Message}";
                Console.WriteLine("=======>>" + msgError);
                return false;
            }
            return true;
        }



    }
}