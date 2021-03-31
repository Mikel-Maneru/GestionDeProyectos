using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeProyectos
{
    public partial class AñadirCentroCoste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdd_InsertCC(object sender, EventArgs e)
        {
            try
            {
                using (DataAccess da = new DataAccess())
                {

                    Boolean create = true;
                    CentroCoste cc = new CentroCoste();

                    
                    


                    //Identificador textbox
                    if (tbx_ABuscarCC.Text != String.Empty)
                    {
                        tbx_ABuscarCC.BorderColor = default;
                        cc.CC_ID = tbx_ABuscarCC.Text;
                    }
                    else
                    {
                        create = false;
                        tbx_ABuscarCC.BorderColor = System.Drawing.Color.Red;
                    }

                    cc.DESCRIPCION = txb_ADescripcionCC.InnerText;

                    if (create)
                    {
                        da.CreateCC(cc);
                        Response.Write("<script>alert('El centro de coste se ha añadido.')</script>");
                        tbx_ABuscarCC.Text = "";
                        txb_ADescripcionCC.InnerText = "";
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exception)
            {
                string error = exception.Message;
                if (error.StartsWith("ORA-00001:"))
                {
                    tbx_ABuscarCC.BorderColor = System.Drawing.Color.Red;
                    Response.Write("<script>alert('Ese identificador ya existe!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Has alcanzado el limite de uno de los campos: " + error + " ')</script>");
                }
            }
        }
    }
}