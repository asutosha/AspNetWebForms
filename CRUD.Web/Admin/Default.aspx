<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD.Web.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">
    <div class="row">
        <h3>Bem vindo ao Projeto</h3>
        <hr />

        <ul>
            <li><a href="Pages/AlterarSenha.aspx">Alterar Senha</a></li>
            <li><a href="Pages/CadastroCliente.aspx">Cadastrar Cliente</a></li>
            <li><a href="Pages/PesquisaCliente.aspx">Pesquisar Cliente</a></li>
            <li><a href="Pages/ReportClientes.aspx">Relatório de Clientes</a></li>
        </ul>

    </div>
</asp:Content>
