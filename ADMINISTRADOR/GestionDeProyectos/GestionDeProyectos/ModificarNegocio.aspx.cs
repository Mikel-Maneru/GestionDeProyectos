using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeProyectos
{
    public partial class ModificarNegocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModify_getNegocio(object Sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                try
                {
                    if (tbx_BuscarNegocio.Text != String.Empty)
                    {
                        tbx_BuscarNegocio.BorderColor = default;
                        Negocio negocio = da.GetNegocio(tbx_BuscarNegocio.Text);
                        txb_DescripcionNegocio.InnerText = negocio.DESCRIPCION;
                    }
                    else
                    {
                        tbx_BuscarNegocio.BorderColor = System.Drawing.Color.Red;
                    }
                    
                }
                catch
                {
                    tbx_BuscarNegocio.BorderColor = System.Drawing.Color.Red;
                    txb_DescripcionNegocio.InnerText = "-";
                }
            }
        }

        protected void btnModify_deleteNegocio(object Sender, EventArgs e)
        {

            using (DataAccess da = new DataAccess())
            {
                int rows;
                try
                {
                    if (tbx_BuscarNegocio.Text != String.Empty)
                    {
                        tbx_BuscarNegocio.BorderColor = default;
                        rows = da.DeleteNegocio(tbx_BuscarNegocio.Text);
                        if (rows == 0)
                        {
                            tbx_BuscarNegocio.BorderColor = System.Drawing.Color.Red;
                            Response.Write("<script>alert('No hemos podido encontrar el Negocio " + tbx_BuscarNegocio.Text + ", Por favor revise que lo ha metido correctamente e inténtelo de nuevo.')</script>");
                        }
                        else
                        {
                            tbx_BuscarNegocio.Text = "";
                            txb_DescripcionNegocio.InnerText = "";

                        }
                    }
                    else
                    {
                        tbx_BuscarNegocio.BorderColor = System.Drawing.Color.Red;
                    }
                }
                catch
                {
                    Response.Write("<script>alert('No hemos podido eliminar el Negocio " + tbx_BuscarNegocio.Text + ", debido a que algun/os proyecto/s esta/n haciendo uso de él, por favor modifiqué dicho/s proyecto/s e intentelo de nuevo.')</script>");
                }
            }
        }

        protected void btnModify_updateNegocio(object Sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                try
                {
                    Negocio negocio = new Negocio();

                    if (tbx_BuscarNegocio.Text != String.Empty)
                    {
                        tbx_BuscarNegocio.BorderColor = default;
                        negocio.NEGOCIO_ID = tbx_BuscarNegocio.Text;
                        negocio.DESCRIPCION = txb_DescripcionNegocio.InnerText;
                        da.UpdateNegocio(negocio);
                        negocio = da.GetNegocio(tbx_BuscarNegocio.Text);
                    }
                    else
                    {
                        tbx_BuscarNegocio.BorderColor = System.Drawing.Color.Red;
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