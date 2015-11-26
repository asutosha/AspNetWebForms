using CRUD.DAL.Persistence;
using CRUD.Entities;
using CRUD.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Web.Admin.Pages
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEstados.DataSource = Enum.GetNames(typeof(Estado));
                ddlEstados.DataBind();
                ddlEstados.Items.Insert(0, new ListItem("- Escolha uma opção -", ""));
            }
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente();
                c.Endereco = new Endereco();

                //Cliente
                c.Nome = txtNome.Text;
                c.Rg = txtRg.Text;
                c.Cpf = txtCpf.Text;

                //Endereco do Cliente
                c.Endereco.Descricao = txtDescricao.Text;
                c.Endereco.Bairro = txtBairro.Text;
                c.Endereco.Cidade = txtCidade.Text;
                c.Endereco.Estado = (Estado)Enum.Parse(typeof(Estado), ddlEstados.SelectedValue);
                c.Endereco.Cep = txtCep.Text;

                ClienteDAL d = new ClienteDAL();

                if (d.FindByCpf(c.Cpf) > 0)
                {
                    lblMensagem.Text = "Cliente já cadastrado!";
                }
                else
                {
                    d.Inert(c);

                    lblMensagem.Text = "Cliente " + c.Nome + ", cadastrado com sucesso.";

                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtRg.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            ddlEstados.SelectedIndex = 0;
            txtCep.Text = string.Empty;
        }
    }
}