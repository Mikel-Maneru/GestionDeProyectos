using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GestionDeProyectos.Models;


namespace GestionDeProyectos
{
    public partial class ModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnModify_deleteCliente(object Sender, EventArgs e)
        {

            using (DataAccess da = new DataAccess())
            {
                int rows;
                try
                {
                    if (txb_findproyect.Text != String.Empty)
                    {
                        txb_findproyect.BorderColor = default;
                        rows = da.DeleteCliente(txb_findproyect.Text);
                        if (rows == 0)
                        {
                            txb_findproyect.BorderColor = System.Drawing.Color.Red;
                            Response.Write("<script>alert('No hemos podido encontrar el cliente " + txb_findproyect.Text + ", Por favor revise que lo ha metido correctamente e inténtelo de nuevo.')</script>");
                        }
                        else
                        {
                            txb_findproyect.Text = "";
                            tbx_MIdentificadorCliente.Text = "";
                            tbx_MCIFCliente.Text = "";
                            tbx_MNombreCliente.Text = "";
                            tbx_MDireccionCliente.InnerText = "";
                            tbx_MTelefonoCliente.Text = "";
                            tbx_MEmailCliente.Text = "";
                            tbx_MFaxCliente.Text = "";
                        }
                    }
                    else
                    {
                        txb_findproyect.BorderColor = System.Drawing.Color.Red;
                    }
                }
                catch
                {
                    Response.Write("<script>alert('No hemos podido eliminar el Cliente " + txb_findproyect.Text + ", debido a que algun/os proyecto/s esta/n haciendo uso de él, por favor modifiqué dicho/s proyecto/s e intentelo de nuevo.')</script>");
                }
            }
        }
        protected void btnModify_getCliente(object Sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                tbx_MIdentificadorCliente.BorderColor = default;
                tbx_MNombreCliente.BorderColor = default;
                try
                {
                    if (txb_findproyect.Text != String.Empty)
                    {
                        txb_findproyect.BorderColor = default;
                        Clientes cliente = da.GetCliente(txb_findproyect.Text);

                        tbx_MIdentificadorCliente.Text = cliente.CLIENTE_ID;
                        tbx_MCIFCliente.Text = cliente.CIF;
                        tbx_MNombreCliente.Text = cliente.NOMBRE;
                        tbx_MDireccionCliente.InnerText = cliente.DIRECCION;
                        tbx_MTelefonoCliente.Text = cliente.TELEFONO;
                        tbx_MEmailCliente.Text = cliente.EMAIL;
                        tbx_MFaxCliente.Text = cliente.FAX;
                    }
                    else
                    {
                        txb_findproyect.BorderColor = System.Drawing.Color.Red;
                    }


                }
                catch
                {
                    txb_findproyect.BorderColor = System.Drawing.Color.Red;
                    tbx_MIdentificadorCliente.Text = "-";
                    tbx_MCIFCliente.Text = "-";
                    tbx_MNombreCliente.Text = "-";
                    tbx_MDireccionCliente.InnerText = "-";
                    tbx_MTelefonoCliente.Text = "-";
                    tbx_MEmailCliente.Text = "-";
                    tbx_MFaxCliente.Text = "-";

                }
            }

        }

        protected void btnModify_updateCliente(object Sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                try
                {
                    Boolean update = true;
                    Clientes cliente = new Clientes();

                    if (txb_findproyect.Text != String.Empty)
                    {
                        if (tbx_MIdentificadorCliente.Text != String.Empty)
                        {
                            tbx_MIdentificadorCliente.BorderColor = default;
                            cliente.CLIENTE_ID = tbx_MIdentificadorCliente.Text;
                        } else
                        {
                            tbx_MIdentificadorCliente.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        if (tbx_MNombreCliente.Text != String.Empty)
                        {
                            tbx_MNombreCliente.BorderColor = default;
                            cliente.NOMBRE = tbx_MNombreCliente.Text;
                        }
                        else
                        {
                            tbx_MNombreCliente.BorderColor = System.Drawing.Color.Red;
                            update = false;
                        }

                        cliente.CIF = tbx_MCIFCliente.Text;
                        cliente.DIRECCION = tbx_MDireccionCliente.InnerText;
                        cliente.TELEFONO = tbx_MTelefonoCliente.Text;
                        cliente.EMAIL = tbx_MEmailCliente.Text;
                        cliente.FAX = tbx_MFaxCliente.Text;
                        
                        if (update)
                        {
                            da.UpdateCliente(cliente);
                            cliente = da.GetCliente(tbx_MIdentificadorCliente.Text);
                        }
                    }
                    else
                    {
                        txb_findproyect.BorderColor = System.Drawing.Color.Red;
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