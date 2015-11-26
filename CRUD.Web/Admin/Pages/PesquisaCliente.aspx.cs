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
    public partial class PesquisaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDados();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteDAL d = new ClienteDAL();

                if (ddlEstados.SelectedIndex == 0)
                {
                    gridClientes.DataSource = d.FindAll(txtBairro.Text, txtCidade.Text);
                    gridClientes.DataBind();
                }
                else
                {
                    gridClientes.DataSource = d.FindAll(txtBairro.Text, txtCidade.Text, ddlEstados.SelectedIndex);
                    gridClientes.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                LinkButton btnExcluir = sender as LinkButton;

                int IdCliente = Convert.ToInt32(btnExcluir.CommandArgument);

                ClienteDAL d = new ClienteDAL();
                Cliente c = d.FindById(IdCliente);
                d.Delete(c.IdCliente);

                lblMensagem.Text = "Cliente " + c.Nome + ", excluído com sucesso.";

                CarregarDados();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        private void CarregarDados()
        {
            ddlEstados.DataSource = Enum.GetNames(typeof(Estado));
            ddlEstados.DataBind();
            ddlEstados.Items.Insert(0, new ListItem("- Escolha uma opção -", ""));

            ClienteDAL d = new ClienteDAL();
            gridClientes.DataSource = d.FindAll();
            gridClientes.DataBind();
        }
    }
}