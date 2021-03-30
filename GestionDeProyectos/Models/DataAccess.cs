using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GestionDeProyectos.Models;

namespace GestionDeProyectos.Models
{
    class DataAccess : Base, IDisposable
    {
        private bool disposedValue;

        public List<Clientes> GetClientes()
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM CLIENTES";

            List<DbParameter> prm = new List<DbParameter>();


            List<Clientes> personas = _db.SqlQuery<Clientes>(query, prm.ToArray()).ToList();

            return personas;
        }
        public List<Proyectos> GetProyectos_ID_Nombre()
        {
            if (!OpenDB())
            {
                return null;
            }
            else
            {
                string query = "SELECT PROYECTO_ID AS PROYECTO_ID,NOMBREPROYECTO AS NOMBREPROYECTO FROM PROYECTOS";

                List<Proyectos> proyectos_ID_Nombre = _db.SqlQuery<Proyectos>(query).ToList();

                return proyectos_ID_Nombre;
            }
             
     
        }
        public List<Empleados> comprobarIniciarSesion()
        {
            if (!OpenDB())
            {
                return null;
            }
            else
            {
                string query = "SELECT EMPLEADO_ID AS EMPLEADO_ID ,NOMBRE AS NOMBRE, APELLIDOS AS APELLIDOS, PASSWORD as PASSWORD from Empleados ";

                List<Empleados> empleados = _db.SqlQuery<Empleados>(query).ToList();

                return empleados;
            }


        }
        public List<SubTarea> getTareas(string proyecto_id)
        {
            if (!OpenDB())
            {
                return null;
            }
            else
            {
                //string query = "SELECT * from SUBTAREA where PROYECTO_ID = '"+proyecto_id+"'";
                string query = "SELECT * from SUBTAREA where PROYECTO_ID = :PROYECTO";

                List<DbParameter> prm = new List<DbParameter>();

               DbParameter parameter= _db.CreateParameter("PROYECTO", proyecto_id);

                prm.Add(parameter);

                List<SubTarea> subTareas = _db.SqlQuery<SubTarea>(query,prm.ToArray()).ToList();

                return subTareas;
            }


        }

        public void CreateProyectoEmpleadoTarea(ProyectoEmpleadosTareas pet)
        {
            if (OpenDB())
            {
                string query = "INSERT INTO PROYECTOEMPLEADOTAREAS (TAREA_ID, PROYECTO_ID, EMPLEADO_ID, SUBTAREA_ID,DIA, TIEMPO, OBSERVACION) VALUES ('" + pet.TAREA_ID + "','" + pet.PROYECTO_ID + "','" + pet.EMPLEADO_ID + "','" + pet.SUBTAREA_ID + "','" + pet.DIA + "','" + pet.TIEMPO + "','" + pet.OBSERVACION + "')";


                _db.ExecuteSqlCommand(query);
            }
            else
            {
            }
        }
        public void deleteParte(string tarea_id)
        {
            if (OpenDB())
            {
                string query = "Delete from PROYECTOEMPLEADOTAREAS where TAREA_ID= " + tarea_id;


                _db.ExecuteSqlCommand(query);
            }
            else
            {
            }
        }
        public List<ProyectoEmpleadosTareas> getProyectoEmpleadoTarea(string date , string userid)
        {
            if (OpenDB())
            {
                //string query = "Select proyectoempleadotareas.OBSERVACION,proyectoempleadotareas.TIEMPO,proyectos.NOMBREPROYECTO from proyectoempleadotareas inner join proyectos ON proyectoempleadotareas.PROYECTO_ID = proyectos.PROYECTO_ID  where proyectoempleadotareas.EMPLEADO_ID = '" + userid+ "' AND proyectoempleadotareas.DIA = '" + date+"'" ;
                string query = "Select * from proyectoempleadotareas where EMPLEADO_ID = '" + userid+ "' AND DIA = '" + date+"'" ;
                _db.ExecuteSqlCommand(query);
                List<ProyectoEmpleadosTareas> pet = _db.SqlQuery<ProyectoEmpleadosTareas>(query).ToList();
                return pet;
            }
            else
            {
                return null;
            }
          
        }
        public int getTotalHours(string date, string userid)
        {
            if (OpenDB())
            {
                
                string query = "Select SUM(TIEMPO) Tiempo from proyectoempleadotareas where EMPLEADO_ID = '" + userid + "' AND DIA = '" + date + "'";
                try
                {
                    _db.ExecuteSqlCommand(query);
                    int pet = _db.SqlQuery<int>(query).FirstOrDefault();


                    return pet;

                }
                catch(Exception e)
                {
                    return 0; 
                }

            }
            else
            {
                return 0;
            }
            return 0;
        }
        public List<ProyectoEmpleadosTareas> getallProyectoEmpleadoTarea()
        {
            if (OpenDB())
            {
                //string query = "Select proyectoempleadotareas.OBSERVACION,proyectoempleadotareas.TIEMPO,proyectos.NOMBREPROYECTO from proyectoempleadotareas inner join proyectos ON proyectoempleadotareas.PROYECTO_ID = proyectos.PROYECTO_ID  where proyectoempleadotareas.EMPLEADO_ID = '" + userid+ "' AND proyectoempleadotareas.DIA = '" + date+"'" ;
                string query = "Select TAREA_ID from PROYECTOEMPLEADOTAREAS";
                _db.ExecuteSqlCommand(query);

                List<ProyectoEmpleadosTareas> pet = _db.SqlQuery<ProyectoEmpleadosTareas>(query).ToList();
                return pet;
            }
            else
            {
                return null;
            }

        }
        public List<ProyectoEmpleadoGastos> getAllGastos(string date, string userid)
        {
            if (OpenDB())
            {
                //string query = "Select proyectoempleadotareas.OBSERVACION,proyectoempleadotareas.TIEMPO,proyectos.NOMBREPROYECTO from proyectoempleadotareas inner join proyectos ON proyectoempleadotareas.PROYECTO_ID = proyectos.PROYECTO_ID  where proyectoempleadotareas.EMPLEADO_ID = '" + userid+ "' AND proyectoempleadotareas.DIA = '" + date+"'" ;
                string query = "Select * from proyectoempleadogastos  where EMPLEADO_ID = '" + userid + "' AND DIA = '" + date + "'";
                _db.ExecuteSqlCommand(query);
                List<ProyectoEmpleadoGastos> pet = _db.SqlQuery<ProyectoEmpleadoGastos>(query).ToList();
                return pet;
            }
            else
            {
                return null;
            }

        }
        public List<ProyectoEmpleadoGastos> getgastosid()
        {
            if (OpenDB())
            {
                //string query = "Select proyectoempleadotareas.OBSERVACION,proyectoempleadotareas.TIEMPO,proyectos.NOMBREPROYECTO from proyectoempleadotareas inner join proyectos ON proyectoempleadotareas.PROYECTO_ID = proyectos.PROYECTO_ID  where proyectoempleadotareas.EMPLEADO_ID = '" + userid+ "' AND proyectoempleadotareas.DIA = '" + date+"'" ;
                string query = "Select GASTOS_ID from proyectoempleadogastos";
                try
                {
                    _db.ExecuteSqlCommand(query);

                    List<ProyectoEmpleadoGastos> pet = _db.SqlQuery<ProyectoEmpleadoGastos>(query).ToList();
                    return pet;
                }catch(Exception e)
                {
                    return null;
                }
               
            }
            else
            {
                return null;
            }

        }
        public void CreateProyectoEmpleadoGastos(ProyectoEmpleadoGastos pet)
        {
            if (OpenDB())
            {
                string query = "INSERT INTO ProyectoEmpleadoGastos (GASTOS_ID, PROYECTO_ID, EMPLEADO_ID, DIA,CONCEPTO, OBSERVACION,COSTE,KM,DIETA) VALUES ('" + pet.GASTOS_ID + "','" + pet.PROYECTO_ID + "','" + pet.EMPLEADO_ID + "','" + pet.DIA + "','" + pet.CONCEPTO + "','" + pet.OBSERVACION + "','" + pet.COSTE + "','" + pet.KM + "','" + pet.DIETA + "')";


                _db.ExecuteSqlCommand(query);
            }
            else
            {
            }
        }
        public void deleteGastos(string gastos_id)
        {
            if (OpenDB())
            {
                string query = "Delete from ProyectoEmpleadoGastos where GASTOS_ID= " + gastos_id;


                _db.ExecuteSqlCommand(query);
            }
            else
            {
            }
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~DataAccess()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    

}
