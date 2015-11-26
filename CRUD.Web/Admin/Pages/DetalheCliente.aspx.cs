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
    public partial class DetalheCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //pegando o id na querystring
                    int IdCliente = Int32.Parse(Request.QueryString["cod"]);

                    ClienteDAL d = new ClienteDAL();
                    Cliente c = d.FindById(IdCliente);

                    txtIdCliente.Text = Convert.ToString(c.IdCliente);
                    txtNome.Text = c.Nome;
                    txtRg.Text = c.Rg;
                    txtCpf.Text = c.Cpf;
                    txtDataCadastro.Text = c.DataCadastro.ToString("dd/MM/yyyy");
                    txtDescricao.Text = c.Endereco.Descricao;
                    txtBairro.Text = c.Endereco.Bairro;
                    txtCidade.Text = c.Endereco.Cidade;
                    txtCep.Text = c.Endereco.Cep;

                    //carregando todos os enum para estados no dropdown
                    ddlEstados.DataSource = Enum.GetNames(typeof(Estado));
                    ddlEstados.DataBind();
                    ddlEstados.Items.Insert(0, new ListItem("- Escolha uma opção -", ""));

                    //selecionando o valor cadastrado para o usuario selecionado
                    ddlEstados.SelectedIndex = Convert.ToInt32(c.Endereco.Estado);
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                }
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente();
                c.Endereco = new Endereco();

                //Cliente
                c.IdCliente = Convert.ToInt32(txtIdCliente.Text);
                c.Nome = txtNome.Text;
                c.Rg = txtRg.Text;
                c.Cpf = txtCpf.Text;
                //Endereco Cliente
                c.Endereco.Descricao = txtDescricao.Text;
                c.Endereco.Bairro = txtBairro.Text;
                c.Endereco.Cidade = txtCidade.Text;
                c.Endereco.Estado = (Estado)Enum.Parse(typeof(Estado), ddlEstados.SelectedValue);
                c.Endereco.Cep = txtCep.Text;

                ClienteDAL d = new ClienteDAL();
                d.Update(c);

                lblMensagem.Text = "Cliente " + c.Nome + ", atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}