using CRUD.DAL.Persistence;
using CRUD.Entities;
using CRUD.Util.Criptografia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Web.Pages
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario u = new Usuario();

                ControleCriptografia cc = new ControleCriptografia();

                u.Nome = txtNome.Text;
                u.Email = txtEmail.Text;
                u.Login = txtUsuario.Text;
                u.Senha = cc.EncriptarParaSHA1(txtSenha.Text);

                UsuarioDAL d = new UsuarioDAL();

                if (!d.HasLogin(txtUsuario.Text))
                {
                    if (!d.HasEmail(txtEmail.Text))
                    {
                        d.Insert(u);

                        lblMensagem.Text = "<p style='color: blue;'>Usuário <strong>" + u.Nome + "</strong>, cadastrado com sucesso.<p>";
                    }
                    else
                    {
                        lblMensagem.Text = "Este e-mail já existe na base de dados.";
                    }
                }
                else
                {
                    lblMensagem.Text = "Este login já existe na base de dados.";
                }

                LimparCampos();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtUsuario.Text = string.Empty;
        }
    }
}