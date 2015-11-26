using CRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientControl.Web.Components
{
    public partial class PainelLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UsuarioLogado"] != null)
                {
                    Usuario u = (Usuario)Session["UsuarioLogado"];
                    lblUsuario.Text = u.Login;

                    area.Visible = true;
                }
                else
                {
                    area.Visible = false;
                }
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();

            Session.Remove("UsuarioLogado");
            Session.Abandon();
            Session.Clear();

            FormsAuthentication.RedirectToLoginPage();
        }
    }
}