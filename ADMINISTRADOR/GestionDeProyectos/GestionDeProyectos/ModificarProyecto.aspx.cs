using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace GestionDeProyectos
{
    public partial class ModificarProyecto : System.Web.UI.Page
    {
        public List<ProyectoEmpleado> pe = new List<ProyectoEmpleado>();
        public List<Subtareas> st = new List<Subtareas>();
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
                str_clientes.Add("-- Cliente --");
                for (int i = 0; i < clientes.Count; i++)
                {
                    str_clientes.Add(clientes[i].CLIENTE_ID + " - " + clientes[i].NOMBRE);
                }
                cbx_MProyectoCliente.DataSource = str_clientes;
                cbx_MProyectoCliente.DataBind();

                List<Negocio> negocios = da.GetNegocios();
                List<string> str_negocio = new List<string>();
                str_negocio.Add("-- Negocio --");
                for (int i = 0; i < negocios.Count; i++)
                {
                    str_negocio.Add(negocios[i].NEGOCIO_ID);
                }
                cbx_MProyectoNegocio.DataSource = str_negocio;
                cbx_MProyectoNegocio.DataBind();

                List<CentroCoste> ccs = da.GetCentroCostes();
                List<string> str_cc = new List<string>();
                str_cc.Add("-- Centro de Coste --");
                for (int i = 0; i < ccs.Count; i++)
                {
                    str_cc.Add(ccs[i].CC_ID);
                }
                cbx_MProyectoCC.DataSource = str_cc;
                cbx_MProyectoCC.DataBind();

                List<TipoProyecto> tipos = da.GetTipoProyectos();
                List<string> str_tipos = new List<string>();
                str_tipos.Add("-- Tipo --");
                for (int i = 0; i < tipos.Count; i++)
                {
                    str_tipos.Add(tipos[i].TIPOPROYECTO);
                }
                cbx_MProyectoTipo.DataSource = str_tipos;
                cbx_MProyectoTipo.DataBind();
            }
        }

        protected void btnModify_deleteProject(object Sender, EventArgs e)
        {
            
            using (DataAccess da = new DataAccess())
            {
                int rows;
                    if (txb_findproyect.Text != String.Empty)
                    {
                        txb_findproyect.BorderColor = default;
                        rows = da.DeleteProyecto(txb_findproyect.Text);
                        if (rows == 0)
                        {
                            txb_findproyect.BorderColor = System.Drawing.Color.Red;
                            Response.Write("<script>alert('No hemos podido encontrar el proyecto " + txb_findproyect.Text + ", Por favor revise que lo ha metido correctamente e inténtelo de nuevo.')</script>");
                        } else
                        {
                            txb_findproyect.Text = "";
                            tbx_MProyectoIdentificador.Text = "";
                            tbx_MProyectoNombre.Text = "";
                            cbx_MProyectoCliente.SelectedIndex = 0;
                            cbx_MProyectoNegocio.SelectedIndex = 0;
                            cbx_MProyectoCC.SelectedIndex = 0;
                            cbx_MProyectoTipo.SelectedIndex = 0;
                            cbx_MProyectoEstado.SelectedIndex = 0;
                            tbx_MProyectoDescripcion.InnerText = "";
                            tbx_MProyectoPlazo.Text = "";
                            tbx_MProyectoModalidad.Text = "";
                        }
                    }
                    else
                    {
                        txb_findproyect.BorderColor = System.Drawing.Color.Red;
                    }
                
            }
        }
  

        protected void btnModify_getProject(object Sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                tbx_MProyectoIdentificador.BorderColor = default;
                tbx_MProyectoNombre.BorderColor = default;
                cbx_MProyectoCliente.BorderColor = default;
                cbx_MProyectoNegocio.BorderColor = default;
                cbx_MProyectoCC.BorderColor = default;
                cbx_MProyectoTipo.BorderColor = default;
                cbx_MProyectoEstado.BorderColor = default;
                tbx_MProyectoModalidad.BorderColor = default;
                try
                {
                    if (txb_findproyect.Text != String.Empty)
                    {
                        txb_findproyect.BorderColor = default;
                        Proyectos proyecto = da.GetProyecto(txb_findproyect.Text);
                        Clientes cliente = da.GetCliente(proyecto.CLIENTE_ID);
                        tbx_MProyectoIdentificador.Text = proyecto.PROYECTO_ID;
                        cbx_MProyectoCliente.SelectedValue = proyecto.CLIENTE_ID + " - " + cliente.NOMBRE;
                        cbx_MProyectoNegocio.SelectedValue = proyecto.NEGOCIO_ID;
                        cbx_MProyectoCC.SelectedValue = proyecto.CENTROCOSTE_ID;
                        tbx_MProyectoNombre.Text = proyecto.NOMBREPROYECTO;
                        tbx_MProyectoDescripcion.InnerText = proyecto.RESUMENPROYECTO;
                        cbx_MProyectoTipo.SelectedValue = proyecto.TIPOPROYECTO;
                        tbx_MProyectoPlazo.Text = proyecto.PLAZO;
                        cbx_MProyectoEstado.SelectedValue = proyecto.ESTADO;
                        tbx_MProyectoModalidad.Text = proyecto.MODALIDAD;

                        pe = da.GetEmpleadosPerProyect(txb_findproyect.Text);
                        st = da.GetSubtareasPerProyect(txb_findproyect.Text);
                    } else
                    {
                        txb_findproyect.BorderColor = System.Drawing.Color.Red;
                    }
                } catch
                {
                    txb_findproyect.BorderColor = System.Drawing.Color.Red;
                    tbx_MProyectoIdentificador.Text = "-";
                    tbx_MProyectoNombre.Text = "-";
                    cbx_MProyectoCliente.SelectedIndex = 0;
                    cbx_MProyectoNegocio.SelectedIndex = 0;
                    cbx_MProyectoCC.SelectedIndex = 0;
                    cbx_MProyectoTipo.SelectedIndex = 0;
                    cbx_MProyectoEstado.SelectedIndex = 0;
                    tbx_MProyectoDescripcion.InnerText = "-";
                    tbx_MProyectoPlazo.Text = "-";
                    tbx_MProyectoModalidad.Text = "-";

                }                
            }
        }
        protected void btnModify_updateProject(object Sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                
                    Boolean update = true;
                    Proyectos proyecto = new Proyectos();

                    if (tbx_MProyectoIdentificador.Text != String.Empty)
                    {
                        //Identificador
                        if (tbx_MProyectoIdentificador.Text != String.Empty)
                        {
                            tbx_MProyectoIdentificador.BorderColor = default;
                            proyecto.PROYECTO_ID = tbx_MProyectoIdentificador.Text;
                        }
                        else
                        {
                            tbx_MProyectoIdentificador.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //Cliente_ID
                        if (cbx_MProyectoCliente.SelectedIndex != 0)
                        {
                            cbx_MProyectoCliente.BorderColor = default;
                            string[] cliente = cbx_MProyectoCliente.SelectedValue.Split(' ');
                            proyecto.CLIENTE_ID = cliente[0];
                        }
                        else
                        {
                            cbx_MProyectoCliente.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //Negocio_ID
                        if (cbx_MProyectoNegocio.SelectedIndex != 0)
                        {
                            cbx_MProyectoNegocio.BorderColor = default;
                            proyecto.NEGOCIO_ID = cbx_MProyectoNegocio.Text;
                        }
                        else
                        {
                            cbx_MProyectoNegocio.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //CC_ID
                        if (cbx_MProyectoCC.SelectedIndex != 0)
                        {
                            cbx_MProyectoCC.BorderColor = default;
                            proyecto.CENTROCOSTE_ID = cbx_MProyectoCC.Text;
                        }
                        else
                        {
                            cbx_MProyectoCC.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //Nombre
                        if (tbx_MProyectoNombre.Text != String.Empty)
                        {
                            tbx_MProyectoNombre.BorderColor = default;
                            proyecto.NOMBREPROYECTO= tbx_MProyectoNombre.Text;
                        }
                        else
                        {
                            tbx_MProyectoNombre.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //TipoProyecto
                        if (cbx_MProyectoTipo.SelectedIndex != 0)
                        {
                            cbx_MProyectoTipo.BorderColor = default;
                            proyecto.TIPOPROYECTO = cbx_MProyectoTipo.Text;
                        }
                        else
                        {
                            cbx_MProyectoTipo.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //Estado
                        if (cbx_MProyectoEstado.SelectedIndex != 0)
                        {
                            cbx_MProyectoEstado.BorderColor = default;
                            proyecto.ESTADO = cbx_MProyectoEstado.Text;
                        }
                        else
                        {
                            cbx_MProyectoEstado.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        //Modalidad
                        if (tbx_MProyectoModalidad.Text != String.Empty)
                        {
                            tbx_MProyectoModalidad.BorderColor = default;
                            proyecto.MODALIDAD = tbx_MProyectoModalidad.Text;
                        }
                        else
                        {
                            tbx_MProyectoModalidad.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        proyecto.RESUMENPROYECTO= tbx_MProyectoDescripcion.InnerText;
                        try
                        {
                            tbx_MProyectoPlazo.BorderColor = default;
                            proyecto.PLAZO = DateTime.Parse(tbx_MProyectoPlazo.Text).ToShortDateString();
                        } catch (Exception)
                        {
                            tbx_MProyectoPlazo.BorderColor = System.Drawing.Color.Red;
                        }                        


                        if (update)
                        {
                            da.UpdateProyecto(proyecto);
                            proyecto = da.GetProyecto(tbx_MProyectoIdentificador.Text);
                        }
                    }
                    else
                    {
                        tbx_MProyectoIdentificador.BorderColor = System.Drawing.Color.Red;
                    }
                //}
                //catch (Oracle.ManagedDataAccess.Client.OracleException exception)
                //{
                //    string error = exception.Message;
                //    if (error.StartsWith("ORA-01840:") || error.StartsWith("ORA-01830:") || error.StartsWith("ORA-01843:") || error.StartsWith("ORA-01847:") || error.StartsWith("ORA-01858:"))
                //    {
                //        Response.Write("<script>alert('El formato de fecha esta mal, pruebe con dd/MM/aa. " + error + "')</script>");
                //    }
                //    else
                //    {
                //        Response.Write("<script>alert('Has alcanzado el limite de uno de los campos: " + error + " ')</script>");
                //    }
                    
                //}
            }
        }
    }
}