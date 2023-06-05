using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Articulos_Web
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            dgvArticulos.DataSource = negocio.listarConSP();
            dgvArticulos.DataBind();
        }
    }
}