using CRUD.DAL.Persistence;
using CRUD.Entities.DataTransfer;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Web.Admin.Pages
{
    public partial class ReportClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ClienteEnderecoDAL d = new ClienteEnderecoDAL();
                    List<ClienteEnderecoDTO> lista = d.FindAll();

                    ReportDataSource ds = new ReportDataSource("DataSetClientes", lista);

                    ReportViewer.LocalReport.DataSources.Clear();
                    ReportViewer.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("/Report/ReportClientes.rdlc");
                    ReportViewer.LocalReport.DataSources.Add(ds);
                    ReportViewer.DataBind();
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = "Erro ao gerar relatório de clientes. \n" + ex.Message;
                }
            }
        }
    }
}