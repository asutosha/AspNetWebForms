using CRUD.DAL.Persistence;
using CRUD.Entities;
using CRUD.Util.Criptografia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Web.Admin.Pages
{
    public partial class AlterarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario u = (Usuario)Session["UsuarioLogado"];

                int IdUsuario = u.IdUsuario;
                string LoginUsuario = u.Login;

                UsuarioDAL d = new UsuarioDAL();

                ControleCriptografia cc = new ControleCriptografia();

                string SenhaAntiga = cc.EncriptarParaSHA1(txtSenhaAntiga.Text);
                string SenhaNova = cc.EncriptarParaSHA1(txtSenhaNova.Text);

                if (d.ValidateOldPassword(SenhaAntiga, IdUsuario))
                {
                    d.UpdatePassword(SenhaNova, IdUsuario);

                    lblMensagem.Text = "<strong>" + LoginUsuario + "</strong>, sua senha foi alterada com sucesso.";
                }
                else
                {
                    lblMensagem.Text = "Senha antiga é inválida.";
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro ao atualizar senha de usuário. \n" + ex.Message;
            }
        }
    }
}