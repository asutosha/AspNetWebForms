using CRUD.DAL.Persistence;
using CRUD.Util.Criptografia;
using CRUD.Util.RandomUtil;
using CRUD.Util.ReenvioSenha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Web.Pages
{
    public partial class ReenvioDeSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviarSenha_Click(object sender, EventArgs e)
        {
            UsuarioDAL d = new UsuarioDAL();

            if (d.HasEmail(txtEmail.Text))
            {
                ControleCriptografia cc = new ControleCriptografia();

                string random = RandomString.GetRandomString();

                string senha = cc.EncriptarParaSHA1(random);
                string email = txtEmail.Text;

                d.UpdatePassword(senha, email);

                ControleEnvioSenha ces = new ControleEnvioSenha();

                ces.EnvioSenha(email, random);

                lblMensagem.Text = "Senha enviada com sucesso para <strong>" + email + "</strong>";

                LimparCampos();
            }
            else
            {
                lblMensagem.Text = "E-mail não cadastrado.";
            }
        }

        private void LimparCampos()
        {
            txtEmail.Text = string.Empty;
        }
    }
}