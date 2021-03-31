using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeProyectos
{
    public partial class AñadirEmpleado : System.Web.UI.Page
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
                str_roles.Add("-- Seleccione el Rol --");
                for (int i = 0; i < roles.Count; i++)
                {
                    str_roles.Add(roles[i].ROL_ID + " - " + roles[i].NOMBRE);
                }
                cxb_ARolEmpleado.DataSource = str_roles;
                cxb_ARolEmpleado.DataBind();

            }
        }
        protected void btnAdd_InsertEmpleado(object sender, EventArgs e)
        {
            try
            {
                using (DataAccess da = new DataAccess())
                {
                    Empleados empleado = new Empleados();
                    Boolean create = true;

                    //Identificador textbox
                    if (txb_AIdentificadorEmpleado.Text != String.Empty)
                    {
                        txb_AIdentificadorEmpleado.BorderColor = default;
                        empleado.EMPLEADO_ID = txb_AIdentificadorEmpleado.Text;
                    }
                    else
                    {
                        create = false;
                        txb_AIdentificadorEmpleado.BorderColor = System.Drawing.Color.Red;
                    }

                    //Role combobox
                    if (cxb_ARolEmpleado.SelectedIndex != 0)
                    {
                        cxb_ARolEmpleado.BorderColor = default;
                        string[] role = cxb_ARolEmpleado.SelectedValue.Split(' ');
                        empleado.ROL_ID = role[0];
                    }
                    else
                    {
                        create = false;
                        cxb_ARolEmpleado.BorderColor = System.Drawing.Color.Red;
                    }


                    //Nombre textbox
                    if (txb_MNombreEmpleado.Text != String.Empty)
                    {
                        txb_MNombreEmpleado.BorderColor = default;
                        empleado.NOMBRE = txb_MNombreEmpleado.Text;
                    }
                    else
                    {
                        create = false;
                        txb_MNombreEmpleado.BorderColor = System.Drawing.Color.Red;
                    }

                    //Apellidos textbox
                    if (txb_AApellidosEmpleado.Text != String.Empty)
                    {
                        txb_AApellidosEmpleado.BorderColor = default;
                        empleado.APELLIDOS = txb_AApellidosEmpleado.Text;
                    }
                    else
                    {
                        create = false;
                        txb_AApellidosEmpleado.BorderColor = System.Drawing.Color.Red;
                    }
                    
                    //Password textbox
                    if (txb_MContraseñaEmpleado.Text != String.Empty)
                    {
                        txb_MContraseñaEmpleado.BorderColor = default;
                        empleado.PASSWORD = txb_MContraseñaEmpleado.Text;
                    }
                    else
                    {
                        create = false;
                        txb_MContraseñaEmpleado.BorderColor = System.Drawing.Color.Red;
                    }

                    empleado.EMAIL = txb_AEmailEmpleado.Text;
                    empleado.MANODEOBRA = txb_AManoObraEmpleado.Text;

                    
                    if (create)
                    {
                        da.CreateEmpleado(empleado);
                        Response.Write("<script>alert('El empleado se ha añadido.')</script>");
                        txb_AIdentificadorEmpleado.Text = "";
                        txb_MNombreEmpleado.Text = "";
                        txb_AApellidosEmpleado.Text = "";
                        txb_MContraseñaEmpleado.Text = "";
                        txb_AEmailEmpleado.Text = "";
                        txb_AManoObraEmpleado.Text = "";
                        cxb_ARolEmpleado.SelectedIndex = 0;
                    }


                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exception)
            {
                string error = exception.Message;
                if (error.StartsWith("ORA-00001:"))
                {
                    Response.Write("<script>alert('Ese identificador ya existe!')</script>");
                    txb_AIdentificadorEmpleado.BorderColor = System.Drawing.Color.Red;
                } else
                {
                    Response.Write("<script>alert('Has alcanzado el limite de uno de los campos: " + error + " ')</script>");
                }
                

            }
        }
    }
}