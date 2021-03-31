using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.OracleClient;
using System.Linq;
using System.Windows;

namespace GestionDeProyectos.Models
{
    class DataAccess : Base, IDisposable
    {
        private bool disposedValue;

        //ROLES
        public List<Rol> GetRoles()
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM ROL ORDER BY ROL_ID";

            List<DbParameter> prm = new List<DbParameter>();

            List<Rol> roles = _db.SqlQuery<Rol>(query, prm.ToArray()).ToList();

            return roles;
        }
        public Rol GetRole(string id)
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM ROL WHERE ROL_ID = '" + id + "'";

            List<DbParameter> prm = new List<DbParameter>();

            List<Rol> roles = _db.SqlQuery<Rol>(query, prm.ToArray()).ToList();

            Rol rol = roles[0];

            return rol;
        }
        

        //OTROS
        public List<ProyectoEmpleado> GetEmpleadosPerProyect(string id)
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM PROYECTOEMPLEADO WHERE PROYECTO_ID = '" + id + "'";

            List<DbParameter> prm = new List<DbParameter>();

            List<ProyectoEmpleado> empleados = _db.SqlQuery<ProyectoEmpleado>(query, prm.ToArray()).ToList();

            return empleados;
        }
        public List<Subtareas> GetSubtareasPerProyect(string id)
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM SUBTAREA WHERE PROYECTO_ID = '" + id + "'";

            List<DbParameter> prm = new List<DbParameter>();

            List<Subtareas> subtareas = _db.SqlQuery<Subtareas>(query, prm.ToArray()).ToList();

            return subtareas;
        }
        public List<TipoProyecto> GetTipoProyectos()
        {
            if (!OpenDB())
                return null;

            string query = "SELECT TIPOPROYECTO FROM TIPOPROYECTO";

            List<DbParameter> prm = new List<DbParameter>();

            List<TipoProyecto> tps = _db.SqlQuery<TipoProyecto>(query, prm.ToArray()).ToList();

            return tps;
        }
        public void CreateProyectoEmpleados(List<Empleados> empleados, Proyectos pr)
        {
            if (OpenDB())
            {
                foreach(Empleados emp in empleados)
                {
                    string query = "INSERT INTO PROYECTOEMPLEADO (PROYECTO_ID, EMPLEADO_ID, HORAS) VALUES ('" + pr.PROYECTO_ID + "','" + emp.EMPLEADO_ID + "', 0)";
                    _db.ExecuteSqlCommand(query);
                }
            }
        }
        public void CreateProyectoSubtareas(List<Subtareas> subtareas, Proyectos pr)
        {
            if (OpenDB())
            {
                foreach(Subtareas subt in subtareas)
                {
                    string query = "INSERT INTO SUBTAREA (SUBTAREA_ID, PROYECTO_ID, DESCRIPCION) VALUES ('" + subt.SUBTAREA_ID + "','" + pr.PROYECTO_ID + "','" + subt.DESCRIPCION + "')";
                    _db.ExecuteSqlCommand(query);
                }
            }
        }
 


        //CLIENTES
        public void CreateCliente(Clientes cliente)
        {
            if (OpenDB()) 
            { 
                string query = "INSERT INTO CLIENTES (CLIENTE_ID, NOMBRE, DIRECCION, TELEFONO, EMAIL, FAX, CIF) VALUES ('" + cliente.CLIENTE_ID + "','" + cliente.NOMBRE + "','" + cliente.DIRECCION + "','" + cliente.TELEFONO + "','" + cliente.EMAIL + "','" + cliente.FAX + "','" + cliente.CIF + "')";

                List<DbParameter> prm = new List<DbParameter>();

                _db.ExecuteSqlCommand(query);
            }
        }
        public void UpdateCliente(Clientes cliente)
        {
            if (OpenDB())
            {
                string query = "UPDATE CLIENTES SET CIF = '" + cliente.CIF + "', NOMBRE = '" + cliente.NOMBRE+ "', DIRECCION = '" + cliente.DIRECCION + "', TELEFONO = '" + cliente.TELEFONO + "', EMAIL = '" + cliente.EMAIL + "', FAX = '" + cliente.FAX + "' WHERE CLIENTE_ID = '" + cliente.CLIENTE_ID + "'";

                List<DbParameter> prm = new List<DbParameter>();

                _db.ExecuteSqlCommand(query);
            }
        }
        public int DeleteCliente(String cliente_ID)
        {
            if (OpenDB())
            {
                string query = "DELETE FROM CLIENTES WHERE CLIENTE_ID = '" + cliente_ID + "'";

                List<DbParameter> prm = new List<DbParameter>();

                return _db.ExecuteSqlCommand(query);
            }
            return 0;
        }
        public List<Clientes> GetClientes()
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM CLIENTES ORDER BY CLIENTE_ID";

            List<DbParameter> prm = new List<DbParameter>();

            List<Clientes> personas = _db.SqlQuery<Clientes>(query, prm.ToArray()).ToList();

            return personas;
        }
        public Clientes GetCliente(string id)
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM CLIENTES WHERE CLIENTE_ID = '" + id + "'";

            List<DbParameter> prm = new List<DbParameter>();

            List<Clientes> clientes = _db.SqlQuery<Clientes>(query, prm.ToArray()).ToList();

            Clientes cliente = clientes[0];

            return cliente;
        }
        

        //PROYECTOS
        public void CreateProyecto(Proyectos proyecto)
        {
            
                if (OpenDB())
                {
                    string query = "INSERT INTO PROYECTOS (PROYECTO_ID, CLIENTE_ID, NEGOCIO_ID, CENTROCOSTE_ID, NOMBREPROYECTO, RESUMENPROYECTO, TIPOPROYECTO, PLAZO, ESTADO, MODALIDAD) VALUES ('" + proyecto.PROYECTO_ID + "','" + proyecto.CLIENTE_ID + "','" + proyecto.NEGOCIO_ID + "','" + proyecto.CENTROCOSTE_ID + "','" + proyecto.NOMBREPROYECTO + "','" + proyecto.RESUMENPROYECTO + "','" + proyecto.TIPOPROYECTO + "','" + proyecto.PLAZO + "','" + proyecto.ESTADO + "','" + proyecto.MODALIDAD + "')";

                    List<DbParameter> prm = new List<DbParameter>();

                    _db.ExecuteSqlCommand(query);
                }           
            
            
        }
        public void UpdateProyecto(Proyectos proyecto)
        {
            if (OpenDB())
            {
                string query = "UPDATE PROYECTOS SET CLIENTE_ID = '" + proyecto.CLIENTE_ID + "', NEGOCIO_ID = '" + proyecto.NEGOCIO_ID + "', CENTROCOSTE_ID = '" + proyecto.CENTROCOSTE_ID + "', NOMBREPROYECTO = '" + proyecto.NOMBREPROYECTO + "', RESUMENPROYECTO = '" + proyecto.RESUMENPROYECTO + "', TIPOPROYECTO = '" + proyecto.TIPOPROYECTO + "', PLAZO = '" + proyecto.PLAZO + "', ESTADO = '" + proyecto.ESTADO + "', MODALIDAD = '" + proyecto.MODALIDAD + "' WHERE PROYECTO_ID = '" + proyecto.PROYECTO_ID + "'";

                List<DbParameter> prm = new List<DbParameter>();

                _db.ExecuteSqlCommand(query);
            }
        }
        public int DeleteProyecto(String proyecto_ID)
        {
            if (OpenDB())
            {
                string query = "DELETE FROM PROYECTOEMPLEADO WHERE PROYECTO_ID = '" + proyecto_ID + "'";
                _db.ExecuteSqlCommand(query);
                query = "DELETE FROM SUBTAREA WHERE PROYECTO_ID = '" + proyecto_ID + "'";
                _db.ExecuteSqlCommand(query);
                query = "DELETE FROM PROYECTOS WHERE PROYECTO_ID = '" + proyecto_ID + "'";
                return _db.ExecuteSqlCommand(query);
            }
            return 0;
        }
        public List<Proyectos> GetProyectos()
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM PROYECTOS ORDER BY PROYECTO_ID";

            List<DbParameter> prm = new List<DbParameter>();

            List<Proyectos> proyectos = _db.SqlQuery<Proyectos>(query, prm.ToArray()).ToList();

            return proyectos;
        }
        public Proyectos GetProyecto(string id)
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM PROYECTOS WHERE PROYECTO_ID = '" + id + "'";

            List<DbParameter> prm = new List<DbParameter>();

            List<Proyectos> proyectos = _db.SqlQuery<Proyectos>(query, prm.ToArray()).ToList();

            Proyectos proyecto = proyectos[0];

            return proyecto;
        }


        //CENTRO DE COSTE
        public void CreateCC(CentroCoste cc)
        {
            if (OpenDB())
            {
                string query = "INSERT INTO CENTROCOSTE (CC_ID, DESCRIPCION) VALUES ('" + cc.CC_ID+ "','" + cc.DESCRIPCION + "')";

                List<DbParameter> prm = new List<DbParameter>();

                _db.ExecuteSqlCommand(query);
            }
        } 
        public void UpdateCC(CentroCoste cc)
        {
            if (OpenDB())
            {
                string query = "UPDATE CENTROCOSTE SET DESCRIPCION = '" + cc.DESCRIPCION + "' WHERE CC_ID = '" + cc.CC_ID+ "'";

                List<DbParameter> prm = new List<DbParameter>();

                _db.ExecuteSqlCommand(query);
            }
        }
        public int DeleteCC(String cc_ID)
        {
            if (OpenDB())
            {
                string query = "DELETE FROM CENTROCOSTE WHERE CC_ID = '" + cc_ID + "'";

                List<DbParameter> prm = new List<DbParameter>();

                return _db.ExecuteSqlCommand(query);
            }
            return 0;
        }
        public List<CentroCoste> GetCentroCostes()
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM CENTROCOSTE ORDER BY CC_ID";

            List<DbParameter> prm = new List<DbParameter>();

            List<CentroCoste> ccs = _db.SqlQuery<CentroCoste>(query, prm.ToArray()).ToList();

            return ccs;
        }
        public CentroCoste GetCentroCoste(string id)
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM CENTROCOSTE WHERE CC_ID = '" + id + "'";

            List<DbParameter> prm = new List<DbParameter>();

            List<CentroCoste> ccs = _db.SqlQuery<CentroCoste>(query, prm.ToArray()).ToList();

            CentroCoste cc = ccs[0];

            return cc;
        }


        //NEGOCIO
        public void CreateNegocio(Negocio negocio)
        {
            if (OpenDB())
            {
                string query = "INSERT INTO NEGOCIO (NEGOCIO_ID, DESCRIPCION) VALUES ('" + negocio.NEGOCIO_ID + "','" + negocio.DESCRIPCION + "')";

                List<DbParameter> prm = new List<DbParameter>();

                _db.ExecuteSqlCommand(query);
            }
        }
        public void UpdateNegocio(Negocio negocio)
        {
            if (OpenDB())
            {
                string query = "UPDATE NEGOCIO SET DESCRIPCION = '" + negocio.DESCRIPCION + "' WHERE NEGOCIO_ID = '" + negocio.NEGOCIO_ID + "'";

                List<DbParameter> prm = new List<DbParameter>();

                _db.ExecuteSqlCommand(query);
            }
        }
        public int DeleteNegocio(String negocio_ID)
        {
            if (OpenDB())
            {
                string query = "DELETE FROM NEGOCIO WHERE NEGOCIO_ID = '" + negocio_ID + "'";

                List<DbParameter> prm = new List<DbParameter>();

                return _db.ExecuteSqlCommand(query);
            }
            return 0;
        }
        public List<Negocio> GetNegocios()
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM NEGOCIO ORDER BY NEGOCIO_ID";

            List<DbParameter> prm = new List<DbParameter>();

            List<Negocio> negocios = _db.SqlQuery<Negocio>(query, prm.ToArray()).ToList();

            return negocios;
        }
        public Negocio GetNegocio(string id)
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM NEGOCIO WHERE NEGOCIO_ID = '" + id + "'";

            List<DbParameter> prm = new List<DbParameter>();

            List<Negocio> negocios = _db.SqlQuery<Negocio>(query, prm.ToArray()).ToList();

            Negocio negocio = negocios[0];

            return negocio;
        }
        

        //EMPLEADOS
        public void CreateEmpleado(Empleados empleado)
        {
            if (OpenDB())
            {
                string query = "INSERT INTO EMPLEADOS (EMPLEADO_ID, NOMBRE, APELLIDOS, PASSWORD, EMAIL, MANODEOBRA, ROL_ID) VALUES ('" + empleado.EMPLEADO_ID + "','" + empleado.NOMBRE + "','" + empleado.APELLIDOS + "','" + empleado.PASSWORD + "','" + empleado.EMAIL + "','" + empleado.MANODEOBRA + "','" + empleado.ROL_ID + "')";

                List<DbParameter> prm = new List<DbParameter>();

                _db.ExecuteSqlCommand(query);
            }
        }
        public void UpdateEmpleado(Empleados empleado)
        {
            if (OpenDB())
            {
                string query = "UPDATE EMPLEADOS SET NOMBRE = '" + empleado.NOMBRE + "', APELLIDOS = '" + empleado.APELLIDOS + "', PASSWORD = '" + empleado.PASSWORD + "', EMAIL = '" + empleado.EMAIL + "', MANODEOBRA = '" + empleado.MANODEOBRA + "', ROL_ID = '" + empleado.ROL_ID + "' WHERE EMPLEADO_ID = '" + empleado.EMPLEADO_ID + "'";

                List<DbParameter> prm = new List<DbParameter>();

                _db.ExecuteSqlCommand(query);
            }
        }
        public int DeleteEmpleado(String empleado_ID)
        {
            if (OpenDB())
            {
                string query = "DELETE FROM EMPLEADOS WHERE EMPLEADO_ID = '" + empleado_ID + "'";

                List<DbParameter> prm = new List<DbParameter>();

                return _db.ExecuteSqlCommand(query);
            }
            return 0;
        }
        public List<Empleados> GetEmpleados()
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM EMPLEADOS ORDER BY EMPLEADO_ID";

            List<DbParameter> prm = new List<DbParameter>();

            List<Empleados> empleados = _db.SqlQuery<Empleados>(query, prm.ToArray()).ToList();

            return empleados;
        }
        public Empleados GetEmpleado(string id)
        {
            if (!OpenDB())
                return null;

            string query = "SELECT * FROM EMPLEADOS WHERE EMPLEADO_ID = '" + id + "'";

            List<DbParameter> prm = new List<DbParameter>();

            List<Empleados> empleados = _db.SqlQuery<Empleados>(query, prm.ToArray()).ToList();

            Empleados empleado = empleados[0];

            return empleado;
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