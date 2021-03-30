using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeProyectos
{
    public partial class Partes : System.Web.UI.Page
    {
        protected List<String> list_proyectos = new List<string>();
        protected List<String> list_tareas = new List<string>();
        protected int tarea_id=0;
        protected string proyectoID;
        protected string empleadoID;
        protected string dia;
        protected string subtareaID;
        protected int tiempo;
        protected string observacion;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
                //gridtable.Visible = false;

                mydate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                using (DataAccess da = new DataAccess())
                {
                    List<Proyectos> list = da.GetProyectos_ID_Nombre();

                    foreach (Proyectos proyectos in list)
                    {
                        list_proyectos.Add(proyectos.PROYECTO_ID + "|" + proyectos.NOMBREPROYECTO);
                    }
                    list_proyectos.Add("--Selecciona un proyecto--");
                   
                    DropDownList_proyetos.DataSource = list_proyectos;
                    DropDownList_proyetos.SelectedIndex = list_proyectos.Count-1 ;
                    DropDownList_proyetos.DataBind();
        
                    chargeGrid();
                }

            }
         

        }
        protected void chargeGrid()
        {
            string data_today = mydate.Text;
            string emp_id = Session["userId"].ToString();
            using (DataAccess da = new DataAccess())
            {
                List<ProyectoEmpleadosTareas> proyectoEmpleadosTareas = da.getProyectoEmpleadoTarea(data_today, emp_id);
                GridViewPET.DataSource = proyectoEmpleadosTareas;
                GridViewPET.DataBind();
                int ht = da.getTotalHours(data_today, emp_id);
                if(ht != 0 || ht != null)
                {
                    Label1.Visible = true;
                    Label1.Text = "Horas Totales: " + ht;
                }
                else if(ht ==0 )
                {
                    Label1.Visible = false;
   
                }
          
            }
               
        }
        protected void gridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        
            Label UserID = (Label)GridViewPET.Rows[e.RowIndex].FindControl("lbltarea");
            using (DataAccess da = new DataAccess())
            {
                da.deleteParte(UserID.Text);
            }

            GridViewPET.EditIndex = -1;
            chargeGrid();
        }
        protected void btn_sum_Click(object sender, EventArgs e)
        {          
            DateTime dtval = DateTime.Parse(mydate.Text);
            DateTime formatteddays = dtval.AddDays(1);
            mydate.Text = formatteddays.ToString("dd/MM/yyyy");
            chargeGrid();

        }
        protected void btn_rest_Click(object sender, EventArgs e)
        {
            DateTime dtval = DateTime.Parse(mydate.Text);        
            DateTime formatteddays = dtval.AddDays(-1);
            mydate.Text = formatteddays.ToString("dd/MM/yyyy");
            chargeGrid();

        }

        protected void DropDownList_proyetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                string proyecto_id = DropDownList_proyetos.Text.ToString().Split('|').First();
      
                List<SubTarea> list = da.getTareas(proyecto_id);

                foreach (SubTarea subTarea in list)
                {
                    list_tareas.Add(subTarea.SUBTAREA_ID+"|"+ subTarea.DESCRIPCION);
                }
                DropDownList_tareas.DataSource = list_tareas;        
                DropDownList_tareas.DataBind();
            }
        }
        protected void btn_insertar(object sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                List<ProyectoEmpleadosTareas> pet = da.getallProyectoEmpleadoTarea();
                ProyectoEmpleadosTareas proyectoEmpleadosTareas = pet.Last();
               
                try {
                    this.tarea_id = Int32.Parse(proyectoEmpleadosTareas.TAREA_ID);
                    this.tarea_id++;

                }
                catch (Exception)
                {
                    this.tarea_id = 1;
                }

                if (Session["userId"] != null)
                {
                    this.empleadoID = Session["userId"].ToString();
                }
                this.proyectoID = DropDownList_proyetos.Text.Split('|').First().ToString();
                this.dia = DateTime.Parse(mydate.Text).ToShortDateString();
                this.subtareaID = DropDownList_tareas.Text.Split('|').First().ToString();
                this.tiempo = Int32.Parse(txt_tiempo.Text);
                this.observacion = TextBox2.Value;
                ProyectoEmpleadosTareas peta = new ProyectoEmpleadosTareas(this.tarea_id.ToString(), this.proyectoID, this.empleadoID, this.dia, this.subtareaID, this.tiempo, this.observacion);
          
                try
                {
                    da.CreateProyectoEmpleadoTarea(peta);
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);

                }
                catch(Exception ea)
                {
                    Console.WriteLine(ea);
                }
           
            }



        }
   
    }
}