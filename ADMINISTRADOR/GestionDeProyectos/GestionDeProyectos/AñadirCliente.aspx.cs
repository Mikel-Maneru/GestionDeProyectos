using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeProyectos
{
    public partial class AñadirCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_InsertClient(object sender, EventArgs e)
        {
            try
            {
                using (DataAccess da = new DataAccess())
                {
                    Clientes cliente = new Clientes();
                    Boolean create = true;

                    //Identificador textbox
                    if (tbx_AIdentificadorCliente.Text != String.Empty)
                    {
                        tbx_AIdentificadorCliente.BorderColor = default;
                        cliente.CLIENTE_ID = tbx_AIdentificadorCliente.Text;
                    }
                    else
                    {
                        create = false;
                        tbx_AIdentificadorCliente.BorderColor = System.Drawing.Color.Red;
                    }

                    //Nombre textbox
                    if (tbx_ANombreCliente.Text != String.Empty)
                    {
                        tbx_ANombreCliente.BorderColor = default;
                        cliente.NOMBRE = tbx_ANombreCliente.Text;
                    }
                    else
                    {
                        create = false;
                        tbx_ANombreCliente.BorderColor = System.Drawing.Color.Red;
                    }

                    cliente.CIF = tbx_ACIFCliente.Text;
                    cliente.CLIENTE_ID = tbx_AIdentificadorCliente.Text;
                    cliente.DIRECCION = tbx_ADireccionCliente.InnerText;
                    cliente.EMAIL = tbx_AEmailCliente.Text;
                    cliente.FAX = tbx_AFaxCliente.Text;
                    cliente.TELEFONO = tbx_ATelefonoCliente.Text;
                    
                    if (create)
                    {
                        da.CreateCliente(cliente);
                        Response.Write("<script>alert('El cliente se ha añadido.')</script>");
                        tbx_AIdentificadorCliente.Text = "";
                        tbx_ACIFCliente.Text = "";
                        tbx_ANombreCliente.Text = "";
                        tbx_ADireccionCliente.InnerText = "";
                        tbx_ATelefonoCliente.Text = "";
                        tbx_AEmailCliente.Text = "";
                        tbx_AFaxCliente.Text = "";
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exception)
            {
                string error = exception.Message;
                if (error.StartsWith("ORA-00001:"))
                {
                    tbx_AIdentificadorCliente.BorderColor = System.Drawing.Color.Red;
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