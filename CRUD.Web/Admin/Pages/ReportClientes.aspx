<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="ReportClientes.aspx.cs" Inherits="CRUD.Web.Admin.Pages.ReportClientes" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

    <div class="row">

        <h3>Relatório de Clientes</h3>
        <a href="../Default.aspx">Voltar</a>
        <hr />

        <div class="col-xs-12">

            <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>

            <asp:ScriptManager ID="Ajax" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="painelAjax" runat="server">

                <ContentTemplate>

                    <rsweb:ReportViewer ID="ReportViewer" runat="server" Width="100%" Height="100%" SizeToReportContent="true">
                    </rsweb:ReportViewer>

                </ContentTemplate>

            </asp:UpdatePanel>

        </div>

    </div>

</asp:Content>
