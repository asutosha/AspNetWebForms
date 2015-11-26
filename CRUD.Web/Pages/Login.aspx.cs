using CRUD.DAL.Persistence;
using CRUD.Entities;
using CRUD.Util.Criptografia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Web.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAL d = new UsuarioDAL();

                ControleCriptografia cc = new ControleCriptografia();

                Usuario u = d.Authenticate(txtUsuario.Text, cc.EncriptarParaSHA1(txtSenha.Text));

                if (u != null)
                {
                    FormsAuthentication.SetAuthCookie(u.Login, chkManterConectado.Checked);

                    Session.Add("UsuarioLogado", u);

                    Response.Redirect("/Admin/Default.aspx");
                }
                else
                {
                    lblMensagem.Text = "Acesso negado.";
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}