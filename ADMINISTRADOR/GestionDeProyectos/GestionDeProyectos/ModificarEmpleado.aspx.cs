using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;

namespace GestionDeProyectos
{
    public partial class ModificarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
            }
        }

        private void BindDropDownList()
        {
            using (DataAccess da = new DataAccess())
            {
                List<Rol> roles = da.GetRoles();
                List<string> str_roles = new List<string>();
                str_roles.Add("-- Seleccione un Rol --");
                for (int i = 0; i < roles.Count; i++)
                {
                    str_roles.Add(roles[i].ROL_ID + " - " + roles[i].NOMBRE);
                }
                cxb_MRolEmpleado.DataSource = str_roles;
                cxb_MRolEmpleado.DataBind();
            }
        }

        protected void btnModify_deleteUser(object Sender, EventArgs e)
        {

            using (DataAccess da = new DataAccess())
            {
                int rows;
                try
                {
                    if (txb_findproyect.Text != String.Empty)
                    {
                        txb_findproyect.BorderColor = default;
                        rows = da.DeleteEmpleado(txb_findproyect.Text);
                        if (rows == 0)
                        {
                            txb_findproyect.BorderColor = System.Drawing.Color.Red;
                            Response.Write("<script>alert('No hemos podido encontrar el empleado " + txb_findproyect.Text + ", Por favor revise que lo ha metido correctamente e inténtelo de nuevo.')</script>");
                        }
                        else
                        {
                            txb_findproyect.Text = "";
                            txb_MIdentificadorEmpleado.Text = "";
                            txb_MNombreEmpleado.Text = "";
                            txb_MApellidosEmpleado.Text = "";
                            txb_MContraseñaEmpleado.Text = "";
                            txb_MEmailEmpleado.Text = "";
                            txb_MManoObraEmpleado.Text = "";
                            cxb_MRolEmpleado.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        txb_findproyect.BorderColor = System.Drawing.Color.Red;
                    }
                }
                catch
                {
                    Response.Write("<script>alert('No hemos podido eliminar el Empleado " + txb_findproyect.Text + ", debido a que algun/os proyecto/s esta/n haciendo uso de él, por favor modifiqué dicho/s proyecto/s e intentelo de nuevo.')</script>");
                }
            }
        }

        protected void btnModify_getUser(object Sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                txb_MIdentificadorEmpleado.BorderColor = default;
                txb_MNombreEmpleado.BorderColor = default;
                txb_MApellidosEmpleado.BorderColor = default;
                txb_MContraseñaEmpleado.BorderColor = default;
                cxb_MRolEmpleado.BorderColor = default;
                try
                {
                    if (txb_findproyect.Text != String.Empty)
                    {
                        txb_findproyect.BorderColor = default;
                        Empleados empleado = da.GetEmpleado(txb_findproyect.Text);
                        Rol rol = da.GetRole(empleado.ROL_ID);
                        txb_MIdentificadorEmpleado.Text = empleado.EMPLEADO_ID;
                        txb_MNombreEmpleado.Text = empleado.NOMBRE;
                        txb_MApellidosEmpleado.Text = empleado.APELLIDOS;
                        txb_MContraseñaEmpleado.Text = empleado.PASSWORD;
                        txb_MEmailEmpleado.Text = empleado.EMAIL;
                        txb_MManoObraEmpleado.Text = empleado.MANODEOBRA;
                        cxb_MRolEmpleado.SelectedValue = rol.ROL_ID + " - " + rol.NOMBRE;
                    }
                    else
                    {
                        txb_findproyect.BorderColor = System.Drawing.Color.Red;
                    }
                    
                }
                catch
                {
                    txb_findproyect.BorderColor = System.Drawing.Color.Red;
                    txb_MIdentificadorEmpleado.Text = "-";
                    txb_MNombreEmpleado.Text = "-";
                    txb_MApellidosEmpleado.Text = "-";
                    txb_MContraseñaEmpleado.Text = "-";
                    txb_MEmailEmpleado.Text = "-";
                    txb_MManoObraEmpleado.Text = "-";
                    cxb_MRolEmpleado.SelectedIndex = 0;
                }
            }
        }

        protected void btnModify_updateUser(object Sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                try
                {
                    Boolean update = true;
                    Empleados empleado = new Empleados();

                    if (txb_findproyect.Text != String.Empty)
                    {
                        //Identificador
                        if (txb_MIdentificadorEmpleado.Text != String.Empty)
                        {
                            txb_MIdentificadorEmpleado.BorderColor = default;
                            empleado.EMPLEADO_ID = txb_MIdentificadorEmpleado.Text;
                        }
                        else
                        {
                            txb_MIdentificadorEmpleado.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //Nombre
                        if (txb_MNombreEmpleado.Text != String.Empty)
                        {
                            txb_MNombreEmpleado.BorderColor = default;
                            empleado.NOMBRE = txb_MNombreEmpleado.Text;
                        }
                        else
                        {
                            txb_MNombreEmpleado.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //Apellidos
                        if (txb_MApellidosEmpleado.Text != String.Empty)
                        {
                            txb_MApellidosEmpleado.BorderColor = default;
                            empleado.APELLIDOS = txb_MApellidosEmpleado.Text;
                        }
                        else
                        {
                            txb_MApellidosEmpleado.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //Contraseña
                        if (txb_MContraseñaEmpleado.Text != String.Empty)
                        {
                            txb_MContraseñaEmpleado.BorderColor = default;
                            empleado.PASSWORD = txb_MContraseñaEmpleado.Text;
                        }
                        else
                        {
                            txb_MContraseñaEmpleado.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //Rol_ID
                        if (cxb_MRolEmpleado.SelectedIndex != 0)
                        {
                            cxb_MRolEmpleado.BorderColor = default;
                            string[] role = cxb_MRolEmpleado.SelectedValue.Split(' ');
                            empleado.ROL_ID = role[0];
                        }
                        else
                        {
                            cxb_MRolEmpleado.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        empleado.EMAIL = txb_MEmailEmpleado.Text;
                        empleado.MANODEOBRA = txb_MManoObraEmpleado.Text;

                        if (update)
                        {
                            da.UpdateEmpleado(empleado);
                            empleado = da.GetEmpleado(txb_MIdentificadorEmpleado.Text);
                        }
                    }
                    else
                    {
                        txb_findproyect.BorderColor = System.Drawing.Color.Red;
                    }
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException exception)
                {
                    string error = exception.Message;
                    Response.Write("<script>alert('Has alcanzado el limite de uno de los campos: " + error + " ')</script>");
                }
            }
        }
    }
}