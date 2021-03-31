using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeProyectos
{
    public partial class AñadirNegocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_InsertNegocio(object sender, EventArgs e)
        {
            try
            {
                using (DataAccess da = new DataAccess())
                {

                    Boolean create = true;

                    Negocio negocio = new Negocio();

                    //Identificador textbox
                    if (tbx_BuscarNegocio.Text != String.Empty)
                    {
                        tbx_BuscarNegocio.BorderColor = default;
                        negocio.NEGOCIO_ID = tbx_BuscarNegocio.Text;
                    }
                    else
                    {
                        create = false;
                        tbx_BuscarNegocio.BorderColor = System.Drawing.Color.Red;
                    }

                    negocio.DESCRIPCION = txb_DescripcionNegocio.InnerText;

                    if (create)
                    {
                        da.CreateNegocio(negocio);
                        Response.Write("<script>alert('El negocio se ha añadido.')</script>");
                        tbx_BuscarNegocio.Text = "";
                        txb_DescripcionNegocio.InnerText = "";
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exception)
            {
                
                string error = exception.Message;
                if (error.StartsWith("ORA-00001:"))
                {
                    tbx_BuscarNegocio.BorderColor = System.Drawing.Color.Red;
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