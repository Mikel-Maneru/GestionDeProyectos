using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GestionDeProyectos.Models;

namespace GestionDeProyectos
{
 
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Convert.ToBoolean(Session["loged"]) || Session["loged"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "active", "show()", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "disable", "disableWindow()", true);

            }
      
          
        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                List<Empleados> empleados = da.comprobarIniciarSesion();
           
                String usuario = TextBox1.Text;
                String contraseña = TextBox2.Text;
                Boolean aurkitu = false;

                foreach (Empleados empleados1 in empleados)
                {
                    if(empleados1.NOMBRE.Equals(usuario) && empleados1.PASSWORD.Equals(contraseña))
                    {
                        aurkitu = true;
                        Session["userId"] = empleados1.EMPLEADO_ID.ToString();
                    }
                }
            
                if (aurkitu)
                {
                    TextBox1.BorderColor = System.Drawing.Color.White;
                    TextBox2.BorderColor = System.Drawing.Color.White;
                    Page.ClientScript.RegisterStartupScript(GetType(), "disable", "disableWindow()", true);
                    Page.ClientScript.RegisterStartupScript(GetType(), "active", "show()", false);
                    Session["user"] = TextBox1.Text;
                    Session["loged"] = true;
                   
                }
                if (!aurkitu)
                {
                    Session["loged"] = false;
                    TextBox1.BorderColor = System.Drawing.Color.Red;
                    TextBox2.BorderColor = System.Drawing.Color.Red;
                             
                }
          
            }
            
        }

    }
}