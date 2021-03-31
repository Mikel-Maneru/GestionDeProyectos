using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeProyectos
{
    public partial class ModificarCentroCoste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModify_deleteCC(object Sender, EventArgs e)
        {

            using (DataAccess da = new DataAccess())
            {
                int rows;
                try
                {
                    if (tbx_MBuscarCC.Text != String.Empty)
                    {
                        tbx_MBuscarCC.BorderColor = default;
                        rows = da.DeleteCC(tbx_MBuscarCC.Text);
                        if (rows == 0)
                        {
                            tbx_MBuscarCC.BorderColor = System.Drawing.Color.Red;
                            Response.Write("<script>alert('No hemos podido encontrar el Centro de Coste " + tbx_MBuscarCC.Text + ", Por favor revise que lo ha metido correctamente e inténtelo de nuevo.')</script>");
                        }
                        else
                        {
                            tbx_MBuscarCC.Text = "";
                            txb_MDescripcionCC.InnerText = "";
                            
                        }
                    }
                    else
                    {
                        tbx_MBuscarCC.BorderColor = System.Drawing.Color.Red;
                    }
                }
                catch
                {
                    Response.Write("<script>alert('No hemos podido eliminar el centro de coste " + tbx_MBuscarCC.Text + ", debido a que algun/os proyecto/s esta/n haciendo uso de él, por favor modifiqué dicho/s proyecto/s e intentelo de nuevo.')</script>");
                }
            }
        }

        protected void btnModify_getCC(object Sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                try
                {
                    CentroCoste cc = new CentroCoste();
                    
                    if (tbx_MBuscarCC.Text != String.Empty)
                    {
                        cc = da.GetCentroCoste(tbx_MBuscarCC.Text);
                        tbx_MBuscarCC.BorderColor = default;
                        txb_MDescripcionCC.InnerText = cc.DESCRIPCION;
                    }
                    else
                    {
                        tbx_MBuscarCC.BorderColor = System.Drawing.Color.Red;
                    }
                }
                catch
                {
                    tbx_MBuscarCC.BorderColor = System.Drawing.Color.Red;
                    txb_MDescripcionCC.InnerText = "-";
                }
            }
        }

        protected void btnModify_updateCC(object Sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                try
                {
                    CentroCoste cc = new CentroCoste();

                    if (tbx_MBuscarCC.Text != String.Empty)
                    {
                        tbx_MBuscarCC.BorderColor = default;
                        cc.CC_ID = tbx_MBuscarCC.Text;
                        cc.DESCRIPCION = txb_MDescripcionCC.InnerText;
                        da.UpdateCC(cc);
                        cc = da.GetCentroCoste(tbx_MBuscarCC.Text);
                    }
                    else
                    {
                        tbx_MBuscarCC.BorderColor = System.Drawing.Color.Red;
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