using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeProyectos
{
    public partial class Gastos : System.Web.UI.Page
    {
        protected List<String> list_proyectos = new List<string>();
        protected int gastos_id = 0;
        protected string proyectoID;
        protected string empleadoID;
        protected string dia;
        protected string concepto;
        protected string observacion;
        protected int coste;
        protected int km;
        protected string dieta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                mydateG.Text = DateTime.Now.ToString("dd/MM/yyyy");

                using (DataAccess da = new DataAccess())
                {
                    List<Proyectos> list = da.GetProyectos_ID_Nombre();

                    foreach (Proyectos proyectos in list)
                    {
                        list_proyectos.Add(proyectos.PROYECTO_ID + "|" + proyectos.NOMBREPROYECTO);
                    }
                    list_proyectos.Add("--Selecciona un proyecto--");

                    DropDownList_proyetos_gastos.DataSource = list_proyectos;
                    DropDownList_proyetos_gastos.SelectedIndex = list_proyectos.Count - 1;
                    DropDownList_proyetos_gastos.DataBind();
                    chargeGrid();
                }
            
            }
        }
        protected void chargeGrid()
        {
            string data_today = mydateG.Text;
            string emp_id = Session["userId"].ToString();
            using (DataAccess da = new DataAccess())
            {
                List<ProyectoEmpleadoGastos> proyectoEmpleadosGastos = da.getAllGastos(data_today, emp_id);
                GridViewG.DataSource = proyectoEmpleadosGastos;
                GridViewG.DataBind();

            }
            DropDownList_proyetos_gastos.SelectedIndex = 3;
            txt_concepto.Text = string.Empty;
            txt_coste.Text = string.Empty;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "active", "clear()", true);
            txt_km.Text = string.Empty;
            chb_dieta.Checked = false;

        }
        protected void gridGastos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            Label gastos_id = (Label)GridViewG.Rows[e.RowIndex].FindControl("lblgastos_id");
            using (DataAccess da = new DataAccess())
            {
                da.deleteGastos(gastos_id.Text);
            }

            GridViewG.EditIndex = -1;
            chargeGrid();
        }
        protected void btn_sum_Click_gastos(object sender, EventArgs e)
        {
            DateTime dtval = DateTime.Parse(mydateG.Text);
            DateTime formatteddays = dtval.AddDays(1);
            mydateG.Text = formatteddays.ToString("dd/MM/yyyy");
            chargeGrid();

        }
        protected void btn_rest_Click_gastos(object sender, EventArgs e)
        {
            DateTime dtval = DateTime.Parse(mydateG.Text);
            DateTime formatteddays = dtval.AddDays(-1);
            mydateG.Text = formatteddays.ToString("dd/MM/yyyy");
            chargeGrid();

        }

        protected void btn_insertar_gastos(object sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                List<ProyectoEmpleadoGastos> gastos = da.getgastosid();
                try
                {
                    ProyectoEmpleadoGastos proyectoEmpleadosTareas = gastos.Last();
                    this.gastos_id = Int32.Parse(proyectoEmpleadosTareas.GASTOS_ID);
                    this.gastos_id++;
                }catch(Exception )
                {
                    this.gastos_id = 1;
                   
                }
               
                if (Session["userId"] != null)
                {
                    this.empleadoID = Session["userId"].ToString();
                }
                this.proyectoID = DropDownList_proyetos_gastos.Text.Split('|').First().ToString();
                this.dia = DateTime.Parse(mydateG.Text).ToShortDateString();
                this.concepto = txt_concepto.Text;
                this.observacion = txt_observacion.Value;
                this.coste = Int32.Parse(txt_coste.Text);
                this.km =Int32.Parse(txt_km.Text);
                if (chb_dieta.Checked)
                {
                    this.dieta = "SI";
                }
                else
                {
                    this.dieta = "NO";
                }
            
                ProyectoEmpleadoGastos peg = new ProyectoEmpleadoGastos(this.gastos_id.ToString(), this.proyectoID, this.empleadoID, this.dia, this.concepto, this.observacion,this.coste,this.km,this.dieta);

                try
                {
                    da.CreateProyectoEmpleadoGastos(peg);
                    //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    chargeGrid();
                }
                catch (Exception ea) 
                {
                    Console.WriteLine(ea);
                }

            }



        }

    }
}