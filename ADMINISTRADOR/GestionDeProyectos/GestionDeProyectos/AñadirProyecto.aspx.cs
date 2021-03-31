using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeProyectos
{
    public partial class AñadirProyecto : System.Web.UI.Page
    {
        public List<Empleados> empleados2;
        public List<Subtareas> subtareas2;
        public List<String> str_empleados;
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

                List<Clientes> clientes = da.GetClientes();
                List<string> str_clientes = new List<string>();
                str_clientes.Add("-- Seleccione un Cliente --");
                for (int i = 0; i < clientes.Count; i++)
                {
                    str_clientes.Add(clientes[i].CLIENTE_ID + " - " + clientes[i].NOMBRE);
                }
                cbx_AProyectoCliente.DataSource = str_clientes;
                cbx_AProyectoCliente.DataBind();

                List<Negocio> negocios = da.GetNegocios();
                List<string> str_negocio = new List<string>();
                str_negocio.Add("-- Seleccione un Negocio --");
                for (int i = 0; i < negocios.Count; i++)
                {
                    str_negocio.Add(negocios[i].NEGOCIO_ID);
                }
                cbx_AProyectoNegocio.DataSource = str_negocio;
                cbx_AProyectoNegocio.DataBind();

                List<CentroCoste> ccs = da.GetCentroCostes();
                List<string> str_cc = new List<string>();
                str_cc.Add("-- Seleccione un Centro de Coste --");
                for (int i = 0; i < ccs.Count; i++)
                {
                    str_cc.Add(ccs[i].CC_ID);
                }
                cbx_AProyectoCC.DataSource = str_cc;
                cbx_AProyectoCC.DataBind();

                List<TipoProyecto> tipos = da.GetTipoProyectos();
                List<string> str_tipos = new List<string>();
                str_tipos.Add("-- Seleccione el Tipo --");
                for (int i = 0; i < tipos.Count; i++)
                {
                    str_tipos.Add(tipos[i].TIPOPROYECTO);
                }
                cbx_AProyectoTipo.DataSource = str_tipos;
                cbx_AProyectoTipo.DataBind();

                List<Empleados> empleados = da.GetEmpleados();
                List<string> str_empleados = new List<string>();
                str_empleados.Add("-- Seleccione un Empleado --");
                for (int i = 0; i < empleados.Count; i++)
                {
                    str_empleados.Add(empleados[i].EMPLEADO_ID + " - " + empleados[i].NOMBRE + " " + empleados[i].APELLIDOS);
                }
                List<Empleados> empleados2 = new List<Empleados>();
                Session["empleados2"] = empleados2;
                List<Subtareas> subtareas2 = new List<Subtareas>();
                Session["subtareas2"] = subtareas2;
                Session["empleados_str"] = str_empleados;
                gridViewUsers.DataSource = empleados2;
                gridViewUsers.DataBind();
                gridViewSubtarea.DataSource = subtareas2;
                gridViewSubtarea.DataBind();
                cbx_AProyectoEmpleados.DataSource = str_empleados;
                cbx_AProyectoEmpleados.DataBind();

            }
        }

        protected void btnAdd_InsertEmpleado(object sender, EventArgs e)
        {
            try
            {
                using (DataAccess da = new DataAccess())
                {
                    cbx_AProyectoEmpleados.BorderColor = default;
                    String[] empleado_id = cbx_AProyectoEmpleados.Text.Split(' ');
                    Empleados emp = da.GetEmpleado(empleado_id[0]);
                    empleados2 = (List<Empleados>) Session["empleados2"];
                    empleados2.Add(emp);
                    gridViewUsers.DataSource = empleados2;
                    gridViewUsers.DataBind();
                    Session["empleados2"] = empleados2;
                    String element = cbx_AProyectoEmpleados.Text.Split(' ').First();
                    List<Empleados> empleados = da.GetEmpleados();
                    str_empleados = (List<String>) Session["empleados_str"];
                    for (int i = 0; i < empleados.Count; i++)
                    {
                        if (element.Equals(empleados[i].EMPLEADO_ID))
                        {
                            str_empleados.Remove(empleados[i].EMPLEADO_ID + " - " + empleados[i].NOMBRE + " " + empleados[i].APELLIDOS);
                        }
                    }
                    Session["empleados_str"] = str_empleados;
                    cbx_AProyectoEmpleados.DataSource = str_empleados;
                    cbx_AProyectoEmpleados.DataBind();

                }
            }
            catch
            {
                cbx_AProyectoEmpleados.BorderColor = System.Drawing.Color.Red;
            }

            //lbl_AProyectoEmpleados.Text = lbl_AProyectoEmpleados.Text + Environment.NewLine + cbx_AProyectoEmpleados.Text;
        }

        protected void btnAdd_InsertSubtarea(object sender, EventArgs e)
        {
            try
            {
                using (DataAccess da = new DataAccess())
                {
                    txb_subtareaID.BorderColor = default;
                    String subtarea_ID = txb_subtareaID.Text;
                    Subtareas subt = new Subtareas();
                    bool insert = true;
                    if (txb_subtareaID.Text != String.Empty)
                    {
                        txb_subtareaID.BorderColor = default;
                        subt.SUBTAREA_ID = txb_subtareaID.Text;
                    }
                    else
                    {
                        txb_subtareaID.BorderColor = System.Drawing.Color.Red;
                        insert = false;
                    }

                    subt.DESCRIPCION = txb_subtareaDesc.InnerText;
                    if (insert)
                    {
                        subtareas2 = (List<Subtareas>)Session["subtareas2"];
                        subtareas2.Add(subt);
                        gridViewSubtarea.DataSource = subtareas2;
                        gridViewSubtarea.DataBind();
                        Session["subtareas2"] = subtareas2;
                        txb_subtareaDesc.InnerText = String.Empty;
                        txb_subtareaID.Text = String.Empty;
                    }
                }
            }
            catch
            {
                tbx_AProyectoIdentificador.BorderColor = System.Drawing.Color.Red;
            }

            //lbl_AProyectoEmpleados.Text = lbl_AProyectoEmpleados.Text + Environment.NewLine + cbx_AProyectoEmpleados.Text;
        }

        protected void gridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
                empleados2 = (List<Empleados>)Session["empleados2"];
                Label lbl_empleado = (Label)gridViewUsers.Rows[e.RowIndex].FindControl("lbl_AProyectoEmpleados");
                String empleado_id = lbl_empleado.Text.Split(' ').First();
                gridViewUsers.EditIndex = -1;
                str_empleados = (List<String>)Session["empleados_str"];
                foreach (Empleados emp in empleados2)
                {
                    if (emp.EMPLEADO_ID.Equals(empleado_id))
                    {
                        empleados2.Remove(emp);
                        str_empleados.Add(emp.EMPLEADO_ID + " - " + emp.NOMBRE + " " + emp.APELLIDOS);
                        break;
                    }
                }
                cbx_AProyectoEmpleados.DataSource = str_empleados;
                cbx_AProyectoEmpleados.DataBind();
                Session["empleados_str"] = str_empleados;
                gridViewUsers.DataSource = empleados2;
                gridViewUsers.DataBind();
                Session["empleados2"] = empleados2;          
        }

        protected void gridViewSubtarea_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            subtareas2 = (List<Subtareas>)Session["subtareas2"];
            Label lbl_subtarea = (Label)gridViewSubtarea.Rows[e.RowIndex].FindControl("lbl_AProyectoSubtarea");
            String subtarea_id = lbl_subtarea.Text;
            gridViewSubtarea.EditIndex = -1;
            foreach (Subtareas subt in subtareas2)
            {
                if (subt.SUBTAREA_ID.Equals(subtarea_id))
                {
                    subtareas2.Remove(subt);
                    break;
                }
            }
            gridViewSubtarea.DataSource = subtareas2;
            gridViewSubtarea.DataBind();
            Session["subtareas2"] = subtareas2;
        }

        protected void btnAdd_InsertProyecto(object sender, EventArgs e)
        {
            try
            {
                using (DataAccess da = new DataAccess())
                {
                    Proyectos proyecto = new Proyectos();
                    Boolean create = true;

                    //Identificador textbox
                    if (tbx_AProyectoIdentificador.Text != String.Empty)
                    {
                        tbx_AProyectoIdentificador.BorderColor = default;
                        proyecto.PROYECTO_ID = tbx_AProyectoIdentificador.Text;
                    }
                    else
                    {
                        create = false;
                        tbx_AProyectoIdentificador.BorderColor = System.Drawing.Color.Red;
                    }

                    //Clientes combobox
                    if (cbx_AProyectoCliente.SelectedIndex != 0)
                    {
                        cbx_AProyectoCliente.BorderColor = default;
                        string[] cliente = cbx_AProyectoCliente.SelectedValue.Split(' ');
                        proyecto.CLIENTE_ID = cliente[0];
                    }
                    else
                    {
                        create = false;
                        cbx_AProyectoCliente.BorderColor = System.Drawing.Color.Red;
                    }

                    //Negocio combobox
                    if (cbx_AProyectoNegocio.SelectedIndex != 0)
                    {
                        cbx_AProyectoNegocio.BorderColor = default;
                        proyecto.NEGOCIO_ID = cbx_AProyectoNegocio.SelectedValue;
                    }
                    else
                    {
                        create = false;
                        cbx_AProyectoNegocio.BorderColor = System.Drawing.Color.Red;
                    }

                    //Centro de Coste combobox
                    if (cbx_AProyectoCC.SelectedIndex != 0)
                    {
                        cbx_AProyectoCC.BorderColor = default;
                        proyecto.CENTROCOSTE_ID = cbx_AProyectoCC.SelectedValue;
                    }
                    else
                    {
                        create = false;
                        cbx_AProyectoCC.BorderColor = System.Drawing.Color.Red;
                    }

                    //Nombre textbox
                    if (tbx_AProyectoNombre.Text != String.Empty)
                    {
                        tbx_AProyectoNombre.BorderColor = default;
                        proyecto.NOMBREPROYECTO = tbx_AProyectoNombre.Text;
                    }
                    else
                    {
                        create = false;
                        tbx_AProyectoNombre.BorderColor = System.Drawing.Color.Red;
                    }

                    proyecto.RESUMENPROYECTO = tbx_AProyectoDescripcion.InnerText;

                    //Tipo proyecto combobox
                    if (cbx_AProyectoTipo.SelectedIndex != 0)
                    {
                        cbx_AProyectoTipo.BorderColor = default;
                        proyecto.TIPOPROYECTO = cbx_AProyectoTipo.SelectedValue;
                    }
                    else
                    {
                        create = false;
                        cbx_AProyectoTipo.BorderColor = System.Drawing.Color.Red;
                    }

                    try
                    {
                        tbx_AProyectoPlazo.BorderColor = default;
                        proyecto.PLAZO = DateTime.Parse(tbx_AProyectoPlazo.Text).ToShortDateString();
                    }
                    catch (Exception)
                    {
                        tbx_AProyectoPlazo.BorderColor = System.Drawing.Color.Red;
                    }

                    //Estado combobox
                    if (cbx_AProyectoEstado.SelectedIndex != 0)
                    {
                        cbx_AProyectoEstado.BorderColor = default;
                        proyecto.ESTADO = cbx_AProyectoEstado.Text;
                    }
                    else
                    {
                        create = false;
                        cbx_AProyectoEstado.BorderColor = System.Drawing.Color.Red;
                    }

                    //Modalidad textbox
                    if (tbx_AProyectoModalidad.Text != String.Empty)
                    {
                        tbx_AProyectoModalidad.BorderColor = default;
                        proyecto.MODALIDAD = tbx_AProyectoModalidad.Text;
                    }
                    else
                    {
                        create = false;
                        tbx_AProyectoModalidad.BorderColor = System.Drawing.Color.Red;
                    }



                    if (create)
                    { 
                        da.CreateProyecto(proyecto);
                        empleados2 = (List<Empleados>)Session["empleados2"];
                        subtareas2 = (List<Subtareas>)Session["subtareas2"];
                        da.CreateProyectoEmpleados(empleados2, proyecto);
                        da.CreateProyectoSubtareas(subtareas2, proyecto);
                        Response.Write("<script> alert('El proyecto se ha añadido.')</script>");
                        BindDropDownList();
                        tbx_AProyectoIdentificador.Text = "";
                        tbx_AProyectoNombre.Text = "";
                        tbx_AProyectoDescripcion.InnerText = "";
                        tbx_AProyectoPlazo.Text = "";
                        tbx_AProyectoModalidad.Text = "";
                        cbx_AProyectoEstado.SelectedIndex = 0;
                        //empleados2 = new List<Empleados>();
                        //Session["empleados2"] = empleados2;
                        //gridViewUsers.DataSource = empleados2;
                        //gridViewUsers.DataBind();
                    }


                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exception)
            {
                string error = exception.Message;
                if (error.StartsWith("ORA-00001:"))
                {
                    Response.Write("<script>alert('Ese identificador ya existe!')</script>");
                    tbx_AProyectoIdentificador.BorderColor = System.Drawing.Color.Red;
                }
                if (error.StartsWith("ORA-01840:") || error.StartsWith("ORA-01830:") || error.StartsWith("ORA-01843:") || error.StartsWith("ORA-01847:") || error.StartsWith("ORA-01861:") || error.StartsWith("ORA-01858:"))
                {
                    Response.Write("<script>alert('El formato de fecha esta mal, pruebe con dd/MM/aa.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Has alcanzado el limite de uno de los campos: " + error + " ')</script>");
                }

            }
            
        }

    }
}