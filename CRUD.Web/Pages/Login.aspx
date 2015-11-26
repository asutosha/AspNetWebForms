<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRUD.Web.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

    <div style="position: relative; height: 50%; width: 50%; margin: 0 auto; resize: both; padding-top: 50%;">
        <div class="col-xs-3 well" style="position: absolute; width: 50%; transform: translate(-50%, -50%); top: 50%; left: 50%; resize: both;">
            <label>Usuário:</label>
            <br />
            <asp:TextBox ID="txtUsuario" runat="server" placeholder="Digite aqui." CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="reqUsuario"
                runat="server"
                ControlToValidate="txtUsuario"
                ErrorMessage="Por favor, infome o usuário."
                ForeColor="Red"
                Display="Dynamic"
            />
            <br />

            <label>Senha:</label>
            <br />
            <asp:TextBox ID="txtSenha" runat="server" placeholder="Digite aqui." CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="reqSenha"
                runat="server"
                ControlToValidate="txtSenha"
                ErrorMessage="Por favor, infome a senha."
                ForeColor="Red"
                Display="Dynamic"
            />
            <br />

            <asp:CheckBox ID="chkManterConectado" runat="server" Checked="true" Text="Manter-me Conectado" />
            <br />
            <br />

            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" Text="Login" OnClick="btnLogin_Click" />
            <br />

            <a href="CadastroUsuario.aspx">Cadastrar usuário</a>
            <br />

            <a href="ReenvioDeSenha.aspx">Solicitar Nova Senha</a>
            <br />

            <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>

        </div>
    </div>

</asp:Content>
