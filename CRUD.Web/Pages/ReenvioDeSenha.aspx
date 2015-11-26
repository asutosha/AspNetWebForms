<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="ReenvioDeSenha.aspx.cs" Inherits="CRUD.Web.Pages.ReenvioDeSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

    <div class="row">

        <h3>Reenvio de Senha</h3>
        <a href="Login.aspx">Voltar</a>
        <hr />

        <div class="col-xs-3 well">

            <label>Informe seu e-mail:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqEmail" runat="server"
                ErrorMessage="Por favor, informe o e-mail."
                ControlToValidate="txtEmail"
                ForeColor="Red"
                Display="Dynamic" />
            <asp:RegularExpressionValidator ID="regexEmail" runat="server"
                ErrorMessage="Formato de e-mail inválido."
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="txtEmail"
                ForeColor="Purple"
                Display="Dynamic" />
            <br />
            <br />

            <asp:Button ID="btnEnviarSenha" runat="server" Text="Enviar Senha" CssClass="btn btn-primary btn-block" OnClick="btnEnviarSenha_Click" />
            <br />

            <asp:Label ID="lblMensagem" runat="server"></asp:Label>

        </div>

    </div>

</asp:Content>
